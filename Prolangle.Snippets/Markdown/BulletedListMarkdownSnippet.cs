using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Markdown;

public class BulletedListMarkdownSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("6529db62-a4a5-4f33-9634-263e681af5de");

	public ILanguage Language => Languages.Markdown.Instance;

	public string Filename => "CONTRIBUTING.md";

	public string SourceCode => //lang=markdown
		"""
		1. [Code of Conduct](#code-of-conduct)
		2. [Report a bug](#report-a-bug)
		3. [Request a feature](#request-a-feature)
		4. [Contribute a language](#contribute-a-language)
		    1. [Choosing a language](#choosing-a-language)
		    2. [Requesting a specific language](#requesting-a-specific-language)
		    3. [Contributing code snippets](#contributing-code-snippets)
		    4. [Adding a language to the Properties Game](#adding-a-language-to-the-properties-game)
		    5. [Adding a code snippet](#adding-a-code-snippet)
		5. [Contributing code](#contributing-code)
		6. [Everything else](#everything-else)
		7. [Legal](#legal)
		""";
}
