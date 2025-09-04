using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Cobol;

public class HelloWorldCobolSnippet : ICodeSnippet, IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("1c3a9f20-e71a-4f21-b334-1ce9f0b58515");

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
