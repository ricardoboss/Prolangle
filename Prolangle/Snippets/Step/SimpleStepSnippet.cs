using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Step;

public class SimpleStepSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Step.Instance;

	public string Filename => "hello.step";

	public string SourceCode =>
		"""
		function hello = (string name) {
			println('Hello, ', name, '!')
		}

		foreach (string name in ['World', 'You']) {
			hello(name)
		}
		""";
}
