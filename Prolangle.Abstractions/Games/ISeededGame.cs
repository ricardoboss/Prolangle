namespace Prolangle.Abstractions.Games;

public interface ISeededGame
{
	Guid Id { get; }

	DateTimeOffset PlayedAt { get; }

	GameSeed GameSeed { get; }
}
