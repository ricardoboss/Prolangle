using Prolangle.Helpers;
using Prolangle.Languages.Framework;
using Prolangle.Models;

namespace Prolangle.Interfaces;

public interface IGuessGame
{
	GameSeed Seed { get; }

	ILanguage TargetLanguage { get; }

	IReadOnlyList<ILanguage> Guesses { get; }

	IEnumerable<ILanguage> RemainingLanguages { get; }

	bool HasWon => Guesses.Contains(TargetLanguage);

	Task GuessLanguage(ILanguage language, CancellationToken cancellationToken = default);

	event AsyncEventHandler<LanguageGuessedEventArgs>? OnGuess;
}
