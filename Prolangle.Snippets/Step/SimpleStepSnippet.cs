using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Step;

public class SimpleStepSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("b1f708b9-cc69-4226-99c4-b4210b37915b");

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
