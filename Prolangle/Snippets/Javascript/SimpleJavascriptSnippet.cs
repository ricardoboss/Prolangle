using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Javascript;

public class SimpleJavascriptSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Javascript.Instance;

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
