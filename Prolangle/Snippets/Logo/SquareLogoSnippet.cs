using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Logo;

public class SquareLogoSnippet : IAttributedCodeSnippet
{
	public string Attribution => "https://personal.utdallas.edu/~veerasam/logo/";
	public string Filename => "square.logo";
	public ILanguage Language => Languages.Logo.Instance;

	public string SourceCode =>
		"cs fd 100 rt 90 fd 100 rt 90 fd 100 rt 90 fd 100";
}
