using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Cobol;

public class HelloWorldCobolSnippet : ICodeSnippet, IAttributedCodeSnippet
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

	public string Attribution => "https://www.ibmmainframer.com/cobol-tutorial/cobol-hello-world/";
}
