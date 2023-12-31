namespace Prolangle.Services;

public class GuessGame
{
	public GuessGame(LanguagesProvider provider, ILogger<GuessGame> logger, Func<int> seeder)
	{
		var languages = provider.Languages;

		var random = new Random(seeder());

		var targetLanguage = languages[random.Next(languages.Count)];
		TargetLanguageId = targetLanguage.Id;

		logger.LogInformation("Target language is {Language}", targetLanguage.Name);
	}

	public Guid TargetLanguageId { get; }
}
