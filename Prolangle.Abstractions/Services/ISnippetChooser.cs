using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Services;

public interface ISnippetChooser
{
	ICodeSnippet ChooseSnippet(GameSeed? gameSeed = null);
}
