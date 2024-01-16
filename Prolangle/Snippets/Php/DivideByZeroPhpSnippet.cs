using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Php;

public class DivideByZeroPhpSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Php.Instance;

	public string Filename => "divide-by-zero.php";

	public string SourceCode =>
		"""
		<?php
		function divide(int $dividend, int $divisor): float {
		  if($divisor == 0) {
		    throw new Exception("Division by zero");
		  }

		  return $dividend / $divisor;
		}

		try {
		  echo divide(5, 0);
		} catch(Exception $e) {
		  echo "Unable to divide.";
		}
		""";
}
