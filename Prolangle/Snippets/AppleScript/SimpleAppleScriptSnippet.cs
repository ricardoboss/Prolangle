using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.AppleScript;

public class SimpleAppleScriptSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.AppleScript.Instance;

	public string SourceCode =>
		"""
		set message to "Hello World!"
		display dialog message
		""";
}
