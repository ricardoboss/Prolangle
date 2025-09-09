namespace Prolangle.Abstractions.Services;

public interface IDatabase
{
	Task OpenAsync(CancellationToken cancellationToken = default);

	bool IsOpen { get; }

	Task MigrateAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

	Task SeedAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

	IAsyncEnumerable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

	Task<T> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default);

	Task AddAsync<T>(T entity, CancellationToken cancellationToken = default);
}
