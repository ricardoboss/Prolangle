using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Games;

public interface ISnippetsGame : IGuessGame<ICodeSnippet, ISnippetsGameGuess, ILanguage>
{
	bool RevealFileName { get; }

	double RevealedPercent { get; }
}
