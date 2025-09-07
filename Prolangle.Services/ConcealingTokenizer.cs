using Blism;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class ConcealingTokenizer(
	ICodeConcealer concealer,
	ITokenizer<GeneralTokenType> inner,
	ILanguage language,
	double revealedOffset,
	double revealedPercent) : ITokenizer<GeneralTokenType>
{
	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		var tokens = inner.Tokenize(code);

		tokens = concealer.ConcealTokens(language, [.. tokens], revealedOffset, revealedPercent);

		return tokens;
	}
}
