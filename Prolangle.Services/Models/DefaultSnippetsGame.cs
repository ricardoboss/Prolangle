using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services.Models;

public class DefaultSnippetsGame : ISnippetsGame
{
	public required Guid Id { get; init; }

	public required DateTimeOffset PlayedAt { get; init; }

	public required GameSeed GameSeed { get; init; }

	public required ICodeSnippet Target { get; init; }

	public required IReadOnlyList<ISnippetsGameGuess> Guesses { get; init; }
}
