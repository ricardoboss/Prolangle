using Prolangle.Abstractions.Games;

namespace Prolangle.Abstractions.Services;

public interface IGuessesRepository<in TTarget, in TGame, TGuess, in TGuessValue>
	where TGame : IGuessGame<TTarget, TGuess, TGuessValue>
	where TGuess : IGuess<TGuessValue>
{
	IAsyncEnumerable<TGuess> GetAllAsync(CancellationToken cancellationToken = default);

	Task<TGuess> CreateAsync(TGame game, TGuessValue guess, CancellationToken cancellationToken = default);
}
