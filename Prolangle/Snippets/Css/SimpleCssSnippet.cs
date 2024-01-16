using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Css;

public class SimpleCssSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Css.Instance;

	public string Filename => "style.css";

	public string SourceCode =>
		"""
		html, body {
			margin: 0;
			padding: 0;
		}

		body {
			background-color: lightblue;
			color: black;
			font-family: Arial, Helvetica, sans-serif;
		}

		p {
			font-size: 16px;
			padding: 10px;
		}

		p:first-letter {
			font-size: 20px;
		}

		@media only screen and (max-width: 600px) {
			body {
				background-color: lightgreen;
			}
		}
		""";
}
