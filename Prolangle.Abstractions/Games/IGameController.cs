using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Games;

public interface IGameController
{
	IReadOnlyList<ILanguage> AvailableLanguages { get; }

	IReadOnlyList<ILanguage> RevealedLanguages { get; }

	ILanguage? TargetLanguage { get; }

	bool Won { get; }

	Task InitializeAsync(GameSeed? gameSeed = null);

	Task GuessAsync(ILanguage language);
}
