using Prolangle.Models;

namespace Prolangle.Interfaces;

public interface IGameHistoryManager
{
	Task<IReadOnlyDictionary<GameSeed, IPropertiesGuessGame>> GetPropertiesGuessGameHistory(CancellationToken cancellationToken = default);

	Task<IReadOnlyDictionary<GameSeed, ISnippetsGuessGame>> GetSnippetsGuessGameHistory(CancellationToken cancellationToken = default);

	Task RecordPropertiesGuessGame(IPropertiesGuessGame game, CancellationToken cancellationToken = default);

	Task RecordSnippetsGuessGame(ISnippetsGuessGame game, CancellationToken cancellationToken = default);
}
