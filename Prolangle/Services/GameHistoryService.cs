using Blazored.LocalStorage;
using Prolangle.Models;

namespace Prolangle.Services;

public class GameHistoryService(ILocalStorageService localStorageService)
{
	private const string Key = "gameHistory";

	private ILocalStorageService _localStorage = localStorageService;

	public async Task WriteAsync(PlayedGame currentGame)
	{
		var games = await _localStorage.GetItemAsync<Stack<PlayedGame>>(Key);

		if (games != null)
		{
			if (games.Peek().TargetLanguageId == currentGame.TargetLanguageId)
				_ = games.Pop();

			games.Push(currentGame);
		}
		else
		{
			games = new Stack<PlayedGame>();
			games.Push(currentGame);
		}

		await _localStorage.SetItemAsync(Key, games);
	}
}
