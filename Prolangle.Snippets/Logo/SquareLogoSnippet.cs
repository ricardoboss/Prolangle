using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Logo;

public class SquareLogoSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("aad0b12f-b4e7-4a83-8079-64dd90715010");

	public string Attribution => "https://personal.utdallas.edu/~veerasam/logo/";
	public string Filename => "square.logo";
	public ILanguage Language => Languages.Logo.Instance;

	public string SourceCode =>
		"cs fd 100 rt 90 fd 100 rt 90 fd 100 rt 90 fd 100";
}
