using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Html;

public class SimpleHtmlSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("b79e8cb0-9127-4f11-9f5c-849f50fc2c61");

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
