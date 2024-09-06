using System.Collections.Immutable;
using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;
using Prolangle.Snippets;

namespace Prolangle.Services;

public class DefaultGuessGameProvider(IGameHistoryManager historyManager, ILanguagesProvider languagesProvider, ITargetLanguageChooser targetLanguageChooser, ISnippetsProvider snippetsProvider, ITargetSnippetChooser targetSnippetChooser)
	: IGuessGameProvider
{
	private const int PropertiesGameSeedOffset = 9;
	private const int SnippetsGameSeedOffset = 17;

	public async Task<IPropertiesGuessGame> GetOrCreatePropertiesGame(
		GameSeed? seed = null,
		IReadOnlyList<ILanguage>? languages = null,
		CancellationToken cancellationToken = default
	)
	{
		var history = await historyManager.GetPropertiesGuessGameHistory(cancellationToken);

		seed ??= GameSeed.FromTimestamp(DateTimeOffset.UtcNow);
		if (history.TryGetValue(seed.Value, out IPropertiesGuessGame? game))
			return game;

		languages ??= languagesProvider.PropertiesGameLanguages;

		ILanguage targetLanguage = targetLanguageChooser.ChooseTargetLanguage(languages, seed.Value, PropertiesGameSeedOffset);

		game = new PropertiesGuessGame(seed.Value, targetLanguage, [], languages.ToImmutableList());

		// make sure to record the game when the user guesses a language
		game.OnGuess += async (_, _, c) => await historyManager.RecordPropertiesGuessGame(game, c);

		// add the game to the history now
		await historyManager.RecordPropertiesGuessGame(game, cancellationToken);

		return game;
	}

	public async Task<ISnippetsGuessGame> GetOrCreateSnippetsGame(
		GameSeed? seed = null,
		IReadOnlyList<ILanguage>? languages = null,
		CancellationToken cancellationToken = default
	)
	{
		var history = await historyManager.GetSnippetsGuessGameHistory(cancellationToken);

		seed ??= GameSeed.FromTimestamp(DateTimeOffset.UtcNow);
		if (history.TryGetValue(seed.Value, out ISnippetsGuessGame? game))
			return game;

		languages ??= languagesProvider.SnippetsGameLanguages;

		ILanguage targetLanguage = targetLanguageChooser.ChooseTargetLanguage(languages, seed.Value, SnippetsGameSeedOffset);

		IEnumerable<ICodeSnippet> availableSnippets = snippetsProvider.GetSnippets(targetLanguage);
		ICodeSnippet targetSnippet = targetSnippetChooser.ChooseTargetSnippet(availableSnippets, seed.Value);

		game = new SnippetsGuessGame(seed.Value, targetLanguage, [], languages.ToImmutableList(), targetSnippet);

		// make sure to record the game when the user guesses a language
		game.OnGuess += async (_, _, c) => await historyManager.RecordSnippetsGuessGame(game, c);

		// add the game to the history now
		await historyManager.RecordSnippetsGuessGame(game, cancellationToken);

		return game;
	}
}
