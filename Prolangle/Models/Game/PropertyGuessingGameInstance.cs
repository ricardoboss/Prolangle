using Prolangle.Services;

namespace Prolangle.Models.Game;

public record PropertyGuessingGameInstance(Guid TargetLanguageId) : GameInstance
{
	public List<Guid> Guesses { get; } = [];

	public async Task<bool> GuessAsync(Guid guessedId, GameHistoryService historyService)
	{
		Guesses.Add(guessedId);

		if (TargetLanguageId != guessedId)
		{
			await historyService.WriteAsync(this);
			return false;
		}
		else
		{
			Won = true;
			await historyService.WriteAsync(this);
			return true;
		}
	}
}
