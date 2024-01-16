using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Php;

public class SimplePhpSnippet : ICodeSnippet
{
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
