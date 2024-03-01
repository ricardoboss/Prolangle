using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Prolangle.Extensions;
using Prolangle.Languages.Framework;

namespace Prolangle.Services;

public class GuessGame
{
	private Func<int> Seeder { get; }

	public GuessGame(LanguagesProvider provider, LanguageSnippetProvider snippetProvider,
		ILogger<GuessGame> logger, GameSeeder seedGenerator,
		IWebAssemblyHostEnvironment environment)
	{
		Seeder = seedGenerator.Seeder;

		MetadatumGameLanguage = _PickRandomLanguage(provider.Languages, seedGenerator);

		if (environment.IsDevelopment())
			logger.LogInformation("Metadatum target language is {Language}", MetadatumGameLanguage.Name);

		SnippetGameLanguage = _PickRandomLanguage(snippetProvider.SupportedLanguages, seedGenerator);

		if (environment.IsDevelopment())
			logger.LogInformation("Snippet target language is {Language}", SnippetGameLanguage.Name);
	}

	private ILanguage _PickRandomLanguage(IEnumerable<ILanguage> availableLanguages,
		GameSeeder seeder)
	{
		ILanguage[] shuffledLanguages = availableLanguages.ToArray();

		return shuffledLanguages.PickWeightedRandom(seeder);
	}

	public ILanguage MetadatumGameLanguage { get; }

	public ILanguage SnippetGameLanguage { get; }
}
