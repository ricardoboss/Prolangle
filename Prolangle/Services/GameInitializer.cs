using Prolangle.Models;
using Prolangle.Models.Game;

namespace Prolangle.Services;

public class GameInitializer
{
	public GameInitializer(LanguagesProvider provider, ILogger<GameInitializer> logger,
		Func<int> seeder)
	{
		var languages = provider.Languages;

		var random = new Random(seeder());

		var targetLanguage = languages[random.Next(languages.Count)];

		PropertyGuessingGameInstance = new PropertyGuessingGameInstance(targetLanguage.Id);

		logger.LogInformation("Target language is {Language}", targetLanguage.Name);
	}

	public PropertyGuessingGameInstance PropertyGuessingGameInstance { get; }
}
