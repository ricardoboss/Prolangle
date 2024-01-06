using Prolangle.Models;
using Prolangle.Models.Game;

namespace Prolangle.Services;

public class GuessGame
{
	private readonly GameHistoryService _gameHistoryService;

	public GuessGame(LanguagesProvider provider, ILogger<GuessGame> logger,
		Func<int> seeder, GameHistoryService gameHistoryService)
	{
		_gameHistoryService = gameHistoryService;

		var languages = provider.Languages;

		var random = new Random(seeder());

		var targetLanguage = languages[random.Next(languages.Count)];

		PropertyGuessingGameInstance = new PropertyGuessingGameInstance(targetLanguage.Id);

		logger.LogInformation("Target language is {Language}", targetLanguage.Name);
	}

	public async Task<bool> GuessAsync(Guid guessedId)
	{
		PropertyGuessingGameInstance.Guesses.Add(guessedId);

		if (PropertyGuessingGameInstance.TargetLanguageId != guessedId)
		{
			await _gameHistoryService.WriteAsync(PropertyGuessingGameInstance);
			return false;
		}
		else
		{
			PropertyGuessingGameInstance.Won = true;
			await _gameHistoryService.WriteAsync(PropertyGuessingGameInstance);
			return true;
		}
	}

	public PropertyGuessingGameInstance PropertyGuessingGameInstance { get; }
}
