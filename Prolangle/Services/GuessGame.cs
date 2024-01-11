using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Prolangle.Languages.Framework;

namespace Prolangle.Services;

public class GuessGame(LanguagesProvider provider, ILogger<GuessGame> logger, Func<int> seeder,
	IWebAssemblyHostEnvironment environment)
{
	public Func<int> Seeder => seeder;

	public ILanguage GetTargetLanguage(IReadOnlyList<ILanguage> languages)
	{
		var random = new Random(seeder());

		var targetLanguage = languages[random.Next(languages.Count)];

		if (environment.IsDevelopment())
		{
			logger.LogInformation("Target language is {Language}", targetLanguage.Name);
		}

		return targetLanguage;
	}
}
