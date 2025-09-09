namespace Prolangle.Abstractions.Games;

public interface IGuessGame<out TTarget, out TGuess, TGuessValue> : ISeededGame where TGuess : IGuess<TGuessValue>
{
	TTarget Target { get; }

	IReadOnlyList<TGuess> Guesses { get; }

	bool Won { get; }
}
