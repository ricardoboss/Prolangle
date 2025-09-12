using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Logo;

public class StarLogoSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("ac773596-c2cf-43d1-bd34-1f6238671082");

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
