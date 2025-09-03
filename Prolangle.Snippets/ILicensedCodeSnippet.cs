namespace Prolangle.Snippets;

public interface ILicensedCodeSnippet : ICodeSnippet
{
	/// <summary>
	/// The license for this code snippet. If set, will be revealed when the
	/// user has won.
	/// </summary>
	string License { get; }
}
