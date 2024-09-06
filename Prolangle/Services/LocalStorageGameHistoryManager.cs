using System.Collections.Immutable;
using Blazored.LocalStorage;
using Prolangle.Interfaces;
using Prolangle.Models;

namespace Prolangle.Services;

public class LocalStorageGameHistoryManager(ILocalStorageService localStorage) : IGameHistoryManager
{
	private const string PropertiesGuessGameHistoryKey = "propertiesGuessGameHistory";
	private const string SnippetsGuessGameHistoryKey = "snippetsGuessGameHistory";

	private ValueTask<bool> HasPropertiesHistory => localStorage.ContainKeyAsync(PropertiesGuessGameHistoryKey);

	public async Task<IReadOnlyDictionary<GameSeed, IPropertiesGuessGame>> GetPropertiesGuessGameHistory(
		CancellationToken cancellationToken = default)
	{
		if (!await HasPropertiesHistory)
			return new Dictionary<GameSeed, IPropertiesGuessGame>();

		var history =
			await localStorage.GetItemAsync<Dictionary<int, PropertiesGuessGame>>(
				PropertiesGuessGameHistoryKey,
				cancellationToken);

		if (history is null)
			return new Dictionary<GameSeed, IPropertiesGuessGame>();

		return history.ToImmutableDictionary(kvp => (GameSeed)kvp.Key, IPropertiesGuessGame (kvp) => kvp.Value);
	}

	public async Task<IReadOnlyDictionary<GameSeed, ISnippetsGuessGame>> GetSnippetsGuessGameHistory(
		CancellationToken cancellationToken = default)
	{
		if (!await HasPropertiesHistory)
			return new Dictionary<GameSeed, ISnippetsGuessGame>();

		var history =
			await localStorage.GetItemAsync<Dictionary<int, SnippetsGuessGame>>(SnippetsGuessGameHistoryKey,
				cancellationToken);

		if (history is null)
			return new Dictionary<GameSeed, ISnippetsGuessGame>();

		return history.ToImmutableDictionary(kvp => (GameSeed)kvp.Key, ISnippetsGuessGame (kvp) => kvp.Value);
	}

	public async Task RecordPropertiesGuessGame(IPropertiesGuessGame game,
		CancellationToken cancellationToken = default)
	{
		if (game is not PropertiesGuessGame propertiesGuessGame)
			throw new ArgumentException("Cannot serialize via interface; must be PropertiesGuessGame", nameof(game));

		IReadOnlyDictionary<GameSeed, IPropertiesGuessGame> readOnlyHistory =
			await GetPropertiesGuessGameHistory(cancellationToken);
		Dictionary<int, PropertiesGuessGame> history =
			readOnlyHistory.ToDictionary(kvp => (int)kvp.Key, kvp => (PropertiesGuessGame)kvp.Value);

		history[(int)propertiesGuessGame.Seed] = propertiesGuessGame;

		await localStorage.SetItemAsync(PropertiesGuessGameHistoryKey, history, cancellationToken);
	}

	public async Task RecordSnippetsGuessGame(ISnippetsGuessGame game, CancellationToken cancellationToken = default)
	{
		if (game is not SnippetsGuessGame snippetsGuessGame)
			throw new ArgumentException("Cannot serialize via interface; must be SnippetsGuessGame", nameof(game));

		IReadOnlyDictionary<GameSeed, ISnippetsGuessGame> readOnlyHistory =
			await GetSnippetsGuessGameHistory(cancellationToken);
		Dictionary<int, SnippetsGuessGame>
			history = readOnlyHistory.ToDictionary(kvp => (int)kvp.Key, kvp => (SnippetsGuessGame)kvp.Value);

		history[(int)snippetsGuessGame.Seed] = snippetsGuessGame;

		await localStorage.SetItemAsync(SnippetsGuessGameHistoryKey, history, cancellationToken);
	}
}
