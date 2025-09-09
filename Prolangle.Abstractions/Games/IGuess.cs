namespace Prolangle.Abstractions.Games;

public interface IGuess<out TTarget>
{
	TTarget Guess { get; }

	DateTimeOffset GuessedAt { get; }
}
