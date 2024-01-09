using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Prolangle.Services;

public class GuessGame
{
	public GuessGame(LanguagesProvider provider, ILogger<GuessGame> logger, Func<int> seeder,
		IWebAssemblyHostEnvironment environment)
	{
		var languages = provider.Languages;

		var random = new Random(seeder());

		var targetLanguage = languages[random.Next(languages.Count)];
		TargetLanguageId = targetLanguage.Id;

		if (environment.Environment == "Development")
		{
			logger.LogInformation("Target language is {Language}", targetLanguage.Name);
		}
	}

	public Guid TargetLanguageId { get; }
}
