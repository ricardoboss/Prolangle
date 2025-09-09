namespace Prolangle.Abstractions.Games;

public interface IGuessTracker<in TGame, in TTarget, in TGuess, in TGuessValue>
	where TGuess : IGuess<TGuessValue>
	where TGame : IGuessGame<TTarget, TGuess, TGuessValue>
{
	Task GuessAsync(TGame game, TGuessValue value, CancellationToken cancellationToken = default);
}
