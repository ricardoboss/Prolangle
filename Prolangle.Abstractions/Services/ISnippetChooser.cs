using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Services;

public interface ISnippetChooser
{
	ICodeSnippet ChooseSnippet(GameSeed? languageSeed = null, GameSeed? snippetSeed = null);
}
