using Blazored.LocalStorage;
using Prolangle.Models;
using Prolangle.Models.Game;

namespace Prolangle.Services;

public class GameHistoryService(ILocalStorageService localStorageService)
{
	private const string Key = "gameHistory";

	private ILocalStorageService _localStorage = localStorageService;

	public async Task WriteAsync(PropertyGuessingGameInstance currentGameInstance)
	{
		var games = await _localStorage.GetItemAsync<Stack<PropertyGuessingGameInstance>>(Key);

		if (games != null)
		{
			if (games.Peek().TargetLanguageId == currentGameInstance.TargetLanguageId)
				_ = games.Pop();

			games.Push(currentGameInstance);
		}
		else
		{
			games = new Stack<PropertyGuessingGameInstance>();
			games.Push(currentGameInstance);
		}

		await _localStorage.SetItemAsync(Key, games);
	}
}
