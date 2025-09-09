using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prolangle.Abstractions.Services;
using TG.Blazor.IndexedDB;

namespace Prolangle.Services;

public class IndexedDbDatabase : IDatabase
{
	private static (string name, int version) IntrospectStore(Type entityType)
	{
		var tableAttribute = entityType.GetCustomAttribute<TableAttribute>();
		var name = tableAttribute?.Name ?? entityType.Name;
		var version = tableAttribute?.Schema is { } versionStr
			? int.Parse(versionStr, NumberStyles.Integer, CultureInfo.InvariantCulture)
			: 1;

		return (name, version);
	}

	internal static void IntrospectTypesAndBuildSchemas(DbStore options, string name, int version, Type[] entityTypes)
	{
		options.DbName = name;
		options.Version = version;

		foreach (var entityType in entityTypes)
			options.Stores.Add(IntrospectType(entityType));
	}

	private static StoreSchema IntrospectType(Type entityType)
	{
		var (name, version) = IntrospectStore(entityType);
		var primaryKey = new IndexSpec { Name = "AutoId", Auto = true };

		return new()
		{
			Name = name,
			DbVersion = version,
			PrimaryKey = primaryKey,
			Indexes =
			[
				// treat all required properties as indexes
				..entityType.GetProperties()
					.Where(p => p.GetCustomAttribute<RequiredAttribute>() != null)
					.Select(property => new IndexSpec
					{
						Name = property.Name,
						KeyPath = property.Name,
						Auto = false,
						Unique = property.GetCustomAttribute<KeyAttribute>() != null,
					}),
			],
		};
	}

	private readonly IndexedDBManager manager;
	private readonly ILogger<IndexedDbDatabase> logger;

	public IndexedDbDatabase(IndexedDBManager manager, ILogger<IndexedDbDatabase> logger)
	{
		this.manager = manager;
		this.logger = logger;

		Initializer = new(InitializeCoreAsync);
	}

	private readonly Lazy<Task> Initializer;

	public Task OpenAsync(CancellationToken cancellationToken = default) => Initializer.Value;

	public bool IsOpen => Initializer is { IsValueCreated: true, Value.IsCompletedSuccessfully: true };

	private async Task InitializeCoreAsync()
	{
		await manager.OpenDb();
		manager.ActionCompleted += ManagerOnActionCompleted;
	}

	private void ManagerOnActionCompleted(object? sender, IndexedDBNotificationArgs e)
	{
		logger.LogTrace("Action completed: {Message} (Outcome: {Outcome})", e.Message, e.Outcome);
	}

	public async IAsyncEnumerable<T> GetAllAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		var (name, _) = IntrospectStore(typeof(T));
		var records = await manager.GetRecords<T>(name);

		foreach (var record in records)
			yield return record;
	}

	public async Task<T> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default)
	{
		var (name, _) = IntrospectStore(typeof(T));

		return await manager.GetRecordById<long, T>(name, id);
	}

	public async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default)
	{
		var (name, _) = IntrospectStore(typeof(T));

		await manager.AddRecord<T>(new()
		{
			Storename = name,
			Data = entity,
		});
	}
}

public static class IndexedDbDatabaseServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddIndexedDbDatabase(this IServiceCollection services, string name, int version,
		Type[] entityTypes)
	{
		services.AddIndexedDB(o => IndexedDbDatabase.IntrospectTypesAndBuildSchemas(o, name, version, entityTypes));
		services.AddScoped<IDatabase, IndexedDbDatabase>();

		return services;
	}
}
