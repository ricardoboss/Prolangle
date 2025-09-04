using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Php;

public class SimplePhpSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("65d70aa8-520f-42ad-91ed-ce72039121f7");

	public ILanguage Language => Languages.Php.Instance;

	public string Filename => "hello-world.php";

	public string SourceCode =>
		"""
		<?php
		if (true) {
		    echo "Hello World!";
		}

		var_dump(PHP_VERSION);
		""";
}
