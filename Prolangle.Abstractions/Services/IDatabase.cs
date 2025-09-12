namespace Prolangle.Abstractions.Services;

public interface IDatabase
{
	Task OpenAsync(CancellationToken cancellationToken = default);

	bool IsOpen { get; }

	IAsyncEnumerable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

	Task<T> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default);

	Task AddAsync<T>(T entity, CancellationToken cancellationToken = default);
}
