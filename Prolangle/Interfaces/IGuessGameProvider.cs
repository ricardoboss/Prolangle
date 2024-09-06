using Prolangle.Languages.Framework;
using Prolangle.Models;

namespace Prolangle.Interfaces;

public interface IGuessGameProvider
{
	Task<IPropertiesGuessGame> GetOrCreatePropertiesGame(
		GameSeed? seed = null,
		IReadOnlyList<ILanguage>? languages = null,
		CancellationToken cancellationToken = default
	);

	Task<ISnippetsGuessGame> GetOrCreateSnippetsGame(
		GameSeed? seed = null,
		IReadOnlyList<ILanguage>? languages = null,
		CancellationToken cancellationToken = default
	);
}
