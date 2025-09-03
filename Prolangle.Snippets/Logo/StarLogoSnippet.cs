using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Logo;

public class StarLogoSnippet : IAttributedCodeSnippet
{
	public string Attribution => "https://personal.utdallas.edu/~veerasam/logo/";
	public string Filename => "star.logo";
	public ILanguage Language => Languages.Logo.Instance;

	public string SourceCode =>
		"""
		REPEAT 4 [
			FD 100
			LT 120
			FD 100
			LT 120
			FD 100
			LT 120
			FD 100
			RT 90
		]
		""";
}
