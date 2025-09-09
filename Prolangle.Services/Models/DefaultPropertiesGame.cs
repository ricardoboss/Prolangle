using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Services.Models;

public class DefaultPropertiesGame : IPropertiesGame
{
	public required Guid Id { get; init; }

	public required DateTimeOffset PlayedAt { get; init; }

	public required GameSeed GameSeed { get; init; }

	public required ILanguage Target { get; init; }

	public required IReadOnlyList<IPropertiesGameGuess> Guesses { get; init; }

	public bool Won => Guesses.Any(g => g.Guess == Target);
}
