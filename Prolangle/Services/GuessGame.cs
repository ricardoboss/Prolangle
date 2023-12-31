namespace Prolangle.Services;

public class GuessGame
{
	public GuessGame(LanguagesProvider provider, ILogger<GuessGame> logger)
	{
		var languages = provider.Languages;

		// seed random number generator with current day of year and select random language
		var random = new Random(DateTime.Now.Hour);

		var targetLanguage = languages[random.Next(languages.Count)];
		TargetLanguageId = targetLanguage.Id;

		logger.LogInformation("Target language is {Language}", targetLanguage.Name);
	}

	public Guid TargetLanguageId { get; }
}
