namespace Prolangle.Snippets.AppleScript;

public class SimpleAppleScriptSnippet : ICodeSnippet
{
	public string SourceCode =>
		"""
		set message to “Hello World!”
		display dialog message
		""";
}
