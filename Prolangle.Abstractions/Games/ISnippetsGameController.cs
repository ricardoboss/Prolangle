using System.Collections.ObjectModel;
using System.ComponentModel;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Games;

public interface ISnippetsGameController
{
	IReadOnlyList<ILanguage> AvailableLanguages { get; }

	ObservableCollection<ILanguage> RevealedLanguages { get; }

	bool Won { get; }

	bool RevealFilename { get; }

	ILanguage? TargetLanguage { get; }

	ICodeSnippet? Snippet { get; }

	double RevealedPercent { get; }

	Task InitializeAsync(GameSeed? gameSeed = null);

	Task GuessAsync(ILanguage language);
}
