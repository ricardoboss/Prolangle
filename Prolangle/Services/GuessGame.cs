using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

		MetadatumGameLanguage = _PickRandomLanguage(provider.Languages);

		if (environment.IsDevelopment())
			logger.LogInformation("Metadatum target language is {Language}", MetadatumGameLanguage.Name);

		SnippetGameLanguage = _PickRandomLanguage(snippetProvider.SupportedLanguages);

		if (environment.IsDevelopment())
			logger.LogInformation("Snippet target language is {Language}", SnippetGameLanguage.Name);
	}

	private ILanguage _PickRandomLanguage(IEnumerable<ILanguage> availableLanguages)
	{
		var random = new Random(Seeder());

		ILanguage[] shuffledLanguages = availableLanguages.ToArray();
		random.Shuffle(shuffledLanguages);

		return shuffledLanguages.First();
	}

	public ILanguage MetadatumGameLanguage { get; }

	public ILanguage SnippetGameLanguage { get; }
}
