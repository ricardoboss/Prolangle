using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Html;

public class SimpleHtmlSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Html.Instance;

	public string Filename => "hello.html";

	public string SourceCode =>
		"""
		<!DOCTYPE html>
		<html>
			<head>
				<title>Page Title</title>

				<meta charset="UTF-8">
				<meta name="description" content="Hello World">
			</head>
			<body>
				<h1>Hello World!</h1>
				<p>This is a paragraph.</p>

				<form action="/action_page.php">
					<label for="fname">First name:</label><br>
					<input type="text" id="fname" name="fname" value="John"><br>
					<label for="lname">Last name:</label><br>
					<input type="text" id="lname" name="lname" value="Doe"><br><br>
					<input type="submit" value="Submit">
				</form>
			</body>
		</html>
		""";
}
