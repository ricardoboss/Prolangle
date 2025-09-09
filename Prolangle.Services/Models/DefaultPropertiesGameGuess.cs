using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Services.Models;

public class DefaultPropertiesGameGuess : IPropertiesGameGuess
{
	public required ILanguage Guess { get; init; }

	public required DateTimeOffset GuessedAt { get; init; }
}
