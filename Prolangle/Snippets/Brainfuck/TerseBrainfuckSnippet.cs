using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Brainfuck;

/// <summary>
/// https://en.wikipedia.org/w/index.php?title=Brainfuck&oldid=1216286405#Hello_World!
/// </summary>
public class TerseBrainfuckSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Brainfuck.Instance;

	public string Filename => "helloworld.bf";

	public string SourceCode =>
		"++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
}