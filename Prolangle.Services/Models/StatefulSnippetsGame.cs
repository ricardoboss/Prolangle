using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services.Models;

public class StatefulSnippetsGame(ISnippetsProvider snippetsProvider) : ISnippetsGame
{
	public required Guid Id { get; init; }

	public required DateTimeOffset PlayedAt { get; init; }

	public required GameSeed GameSeed { get; init; }

	public required ICodeSnippet Target { get; init; }

	public IReadOnlyList<ISnippetsGameGuess> Guesses => ModifiableGuesses;

	public List<ISnippetsGameGuess> ModifiableGuesses { get; } = [];

	public bool Won => Guesses.Any(g => g.Guess == Target.Language);

	public bool RevealFileName => Won || RevealedPercent >= 1;

	public double RevealedPercent => Won ? 1 : Math.Min(1d, Guesses.Count * RevealedPerGuess);

	private double RevealedPerGuess { get; } = 2d / Math.Max(1, snippetsProvider.GetAvailableLanguages().Count());
}
