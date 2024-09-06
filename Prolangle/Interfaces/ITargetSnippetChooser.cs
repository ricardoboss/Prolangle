using Prolangle.Models;
using Prolangle.Snippets;

namespace Prolangle.Interfaces;

public interface ITargetSnippetChooser
{
	ICodeSnippet ChooseTargetSnippet(IEnumerable<ICodeSnippet> availableSnippets, GameSeed seed);
}
