namespace Prolangle.Abstractions.Games;

public interface IGamesProvider<TGame> where TGame : ISeededGame
{
	IAsyncEnumerable<TGame> GetAllAsync(CancellationToken cancellationToken = default);

	Task<TGame?> GetByGameSeedAsync(GameSeed gameSeed, CancellationToken cancellationToken = default);
}
