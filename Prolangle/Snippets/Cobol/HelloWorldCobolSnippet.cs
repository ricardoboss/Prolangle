using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Cobol;

public class HelloWorldCobolSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Cobol.Instance;

	public string Filename => "hello_world.cbl";

	public string SourceCode =>
		"""
		IDENTIFICATION DIVISION.
		PROGRAM-ID. IDSAMPLE.
		ENVIRONMENT DIVISION.
		PROCEDURE DIVISION.
		    DISPLAY 'HELLO WORLD'.
		    STOP RUN.
		""";
}
