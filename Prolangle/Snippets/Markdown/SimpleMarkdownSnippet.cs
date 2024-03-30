using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Markdown;

public class SimpleMarkdownSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Markdown.Instance;

	public string Filename => "README.md";

	public string SourceCode => //lang=markdown
		"""
		# Prolangle

		> A game about programming languages.

		## Credit

		This project was inspired by [progle.net](https://progle.net/) made by
		[Grifel](https://grifel.dev/) & [Marta](https://twitter.com/martaannasz) and you can tip them @
		[ko-fi](https://ko-fi.com/grifel).

		## License

		This project is licensed under the [MIT License](../LICENSE).
		""";
}
