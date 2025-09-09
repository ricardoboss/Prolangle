using System.Runtime.CompilerServices;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Games;

public abstract class DatabaseGamesProvider<TGame>(IDatabase database) : IGamesProvider<TGame> where TGame : ISeededGame
{
	private async Task InitializeAsync()
	{
		if (database.IsOpen)
			return;

		await database.OpenAsync();
		await database.MigrateAsync();
		await database.SeedAsync();
	}

	protected IDatabase Database => database;

	public async Task<TGame> CreateAsync(CancellationToken cancellationToken = default)
	{
		await InitializeAsync();

		return await CreateInternalAsync(cancellationToken);
	}

	protected abstract Task<TGame> CreateInternalAsync(CancellationToken cancellationToken = default);

	public async IAsyncEnumerable<TGame> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		await InitializeAsync();

		await foreach (var game in GetAllInternalAsync(cancellationToken))
			yield return game;
	}

	protected abstract IAsyncEnumerable<TGame> GetAllInternalAsync(CancellationToken cancellationToken = default);

	public async Task<TGame?> GetByGameSeedAsync(GameSeed gameSeed, CancellationToken cancellationToken = default)
	{
		await InitializeAsync();

		return await GetByGameSeedInternalAsync(gameSeed, cancellationToken);
	}

	protected abstract Task<TGame?> GetByGameSeedInternalAsync(GameSeed gameSeed,
		CancellationToken cancellationToken = default);
}
