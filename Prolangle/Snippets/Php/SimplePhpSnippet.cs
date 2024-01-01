namespace Prolangle.Snippets.Php;

public class SimplePhpSnippet : ICodeSnippet
{
	public string SourceCode =>
		"""
		<?php
		if (true) {
		    echo "Hello World!";
		}

		var_dump(PHP_VERSION);
		""";
}
