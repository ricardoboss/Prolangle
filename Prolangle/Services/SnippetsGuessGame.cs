using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;
using Prolangle.Snippets;

namespace Prolangle.Services;

public class SnippetsGuessGame(
	GameSeed seed,
	ILanguage targetLanguage,
	List<ILanguage> guesses,
	IReadOnlyCollection<ILanguage> availableLanguages,
	ICodeSnippet snippet
) : BaseGuessGame(seed, targetLanguage, guesses, availableLanguages), ISnippetsGuessGame
{
	public ICodeSnippet Snippet => snippet;
}
