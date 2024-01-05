using Prolangle.Models;

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

		PlayedGame = new PlayedGame(targetLanguage.Id);

		logger.LogInformation("Target language is {Language}", targetLanguage.Name);
	}

	public async Task<bool> GuessAsync(Guid guessedId)
	{
		PlayedGame.Guesses.Add(guessedId);

		if (PlayedGame.TargetLanguageId != guessedId)
		{
			await _gameHistoryService.WriteAsync(PlayedGame);
			return false;
		}
		else
		{
			PlayedGame.Won = true;
			await _gameHistoryService.WriteAsync(PlayedGame);
			return true;
		}
	}

	public PlayedGame PlayedGame { get; }
}
