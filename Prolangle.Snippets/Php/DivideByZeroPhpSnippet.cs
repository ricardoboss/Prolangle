using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Php;

public class DivideByZeroPhpSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("70d75026-ce5e-4630-9e17-290ea0a711f4");

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
