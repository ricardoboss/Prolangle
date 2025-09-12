using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Javascript;

public class SimpleJavaScriptSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("5757f7ce-7c71-4626-a1e3-d90beeaade34");

	public ILanguage Language => Languages.JavaScript.Instance;

	public string Filename => "script.js";

	public string SourceCode =>
		"""
		function setContent() {
			document.getElementById("demo").innerHTML = "Hello World!";
		}

		function setStyle() {
			var x = document.getElementById("demo");
			x.style.fontSize = "25px";
			x.style.color = "red";
		}

		document.getElementById("demo").onclick = function() {
			setContent();
			setStyle();
		};
		""";
}
