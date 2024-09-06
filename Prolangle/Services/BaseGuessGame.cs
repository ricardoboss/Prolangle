using Prolangle.Helpers;
using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;

namespace Prolangle.Services;

public abstract class BaseGuessGame(
	GameSeed seed,
	ILanguage targetLanguage,
	List<ILanguage> guesses,
	IReadOnlyCollection<ILanguage> availableLanguages
) : IGuessGame
{
	public GameSeed Seed => seed;

	public ILanguage TargetLanguage => targetLanguage;

	public IReadOnlyList<ILanguage> Guesses => guesses;

	public IEnumerable<ILanguage> RemainingLanguages => availableLanguages.Except(guesses);

	public async Task GuessLanguage(ILanguage language, CancellationToken cancellationToken = default)
	{
		guesses.Add(language);

		if (OnGuess is not null)
		{
			var args = new LanguageGuessedEventArgs(language);

			await OnGuess.Invoke(this, args, cancellationToken);
		}
	}

	public event AsyncEventHandler<LanguageGuessedEventArgs>? OnGuess;
}
