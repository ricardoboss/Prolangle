using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Brainfuck;

/// <summary>
/// https://en.wikipedia.org/w/index.php?title=Brainfuck&oldid=1216286405#Hello_World!
/// </summary>
public class TerseBrainfuckSnippet : IAttributedCodeSnippet, ILicensedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("1920c0db-a726-4e09-b2db-cefeeb0e64f4");

	public ILanguage Language => Languages.Brainfuck.Instance;

	public string Filename => "helloworld.bf";

	public string SourceCode =>
		"++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

	public string Attribution => "https://en.wikipedia.org/w/index.php?title=Brainfuck&oldid=1216286405#Hello_World!";
	public string License => "Creative Commons Attribution-ShareAlike License";
}
