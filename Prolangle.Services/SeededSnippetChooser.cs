using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;
using Prolangle.Services.Extensions;

namespace Prolangle.Services;

public class SeededSnippetChooser(IGameSeedProvider gameSeedProvider, ISnippetsProvider snippetsProvider) : ISnippetChooser
{
	public ICodeSnippet ChooseSnippet(GameSeed? gameSeed = null)
	{
		var languages = snippetsProvider.GetAvailableLanguages().ToList();
		if (languages.Count == 0)
			throw new InvalidOperationException("No languages are available");

		gameSeed ??= gameSeedProvider.GetCurrentGameSeed();

		var languagesSeed = gameSeed.Value.Value;
		var targetLanguage = languages.PickRandom(languagesSeed);

		var snippets = snippetsProvider.GetAllForLanguage(targetLanguage).ToList();
		if (snippets.Count == 0)
			throw new InvalidOperationException("No snippets are available");

		var snippetsSeed = gameSeed.Value.Value;
		return snippets.PickRandom(snippetsSeed);
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
