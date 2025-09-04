using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services;

public class SeededSnippetChooser(IGameSeedProvider gameSeedProvider, ISnippetsProvider snippetsProvider) : ISnippetChooser
{
	public ICodeSnippet ChooseSnippet(GameSeed? languageSeed = null, GameSeed? snippetSeed = null)
	{
		var languages = snippetsProvider.GetAvailableLanguages().ToList();
		if (languages.Count == 0)
			throw new InvalidOperationException("No languages are available");

		var languagesSeed = (languageSeed ?? gameSeedProvider.GetCurrentGameSeed(2)).Value;
		languages.Shuffle(languagesSeed);

		var targetLanguage = languages.First();

		var snippets = snippetsProvider.GetAllForLanguage(targetLanguage).ToList();
		if (snippets.Count == 0)
			throw new InvalidOperationException("No snippets are available");

		var snippetsSeed = (snippetSeed ?? gameSeedProvider.GetCurrentGameSeed(3)).Value;
		snippets.Shuffle(snippetsSeed);

		return snippets.First();
	}
}

public static class SeededSnippetChooserServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddSeededSnippetChooser(this IServiceCollection services)
	{
		services.AddSingleton<ISnippetChooser, SeededSnippetChooser>();

		return services;
	}
}
