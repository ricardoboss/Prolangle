namespace Prolangle.Abstractions.Snippets;

public interface IAttributedCodeSnippet : ICodeSnippet
{
	/// <summary>
	/// The attribution for this code snippet. Will be revealed when the user
	/// has won.
	/// </summary>
	string Attribution { get; }
}
