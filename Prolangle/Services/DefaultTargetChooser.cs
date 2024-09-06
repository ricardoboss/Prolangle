using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;
using Prolangle.Snippets;

namespace Prolangle.Services;

public class DefaultTargetChooser : ITargetLanguageChooser, ITargetSnippetChooser
{
	public ILanguage ChooseTargetLanguage(IEnumerable<ILanguage> availableLanguages, GameSeed seed, int seedOffset)
	{
		Random r = seed.GetRandom(seedOffset);

		ILanguage[] languages = availableLanguages.ToArray();

		return languages[r.Next(languages.Length)];
	}

	public ICodeSnippet ChooseTargetSnippet(IEnumerable<ICodeSnippet> availableSnippets, GameSeed seed)
	{
		Random r = seed.GetRandom();

		ICodeSnippet[] snippets = availableSnippets.ToArray();

		return snippets[r.Next(snippets.Length)];
	}
}
