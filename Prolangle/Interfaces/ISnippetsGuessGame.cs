using Prolangle.Snippets;

namespace Prolangle.Interfaces;

public interface ISnippetsGuessGame : IGuessGame
{
	ICodeSnippet Snippet { get; }
}
