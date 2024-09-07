namespace Prolangle.Snippets;

public interface IAttributedCodeSnippet : ICodeSnippet
{
	/// <summary>
	/// The attribution for this code snippet. Will be revealed when the user
	/// has won.
	/// </summary>
	string Attribution { get; }

	/// <summary>
	/// The license for this code snippet. If set, will be revealed when the
	/// user has won.
	/// </summary>
	string? License { get; }
}
