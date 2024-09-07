using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Brainfuck;

/// <summary>
/// https://en.wikipedia.org/w/index.php?title=Brainfuck&oldid=1216286405#Hello_World!
/// </summary>
public class TerseBrainfuckSnippet : IAttributedCodeSnippet
{
	public ILanguage Language => Languages.Brainfuck.Instance;

	public string Filename => "helloworld.bf";

	public string SourceCode =>
		"++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

	public string Attribution => "https://en.wikipedia.org/w/index.php?title=Brainfuck&oldid=1216286405#Hello_World!";
	public string License => "Creative Commons Attribution-ShareAlike License";
}
