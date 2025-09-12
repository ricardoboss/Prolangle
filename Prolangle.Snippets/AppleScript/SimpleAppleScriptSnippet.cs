using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.AppleScript;

public class SimpleAppleScriptSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("8ffcb27e-64cf-4799-a50f-f3c2e1e27d48");

	public ILanguage Language => Languages.AppleScript.Instance;

	public string Filename => "hello-world.applescript";

	public string SourceCode =>
		"""
		set message to "Hello World!"
		display dialog message
		""";
}
