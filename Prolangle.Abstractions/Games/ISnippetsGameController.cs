using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Games;

public interface ISnippetsGameController : IGameController
{
	bool RevealFilename { get; }

	ICodeSnippet? Snippet { get; }

	double RevealedPercent { get; }
}
