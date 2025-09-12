using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class DebugCodeConcealer(ICodeConcealer inner) : ICodeConcealer
{
	public IReadOnlyList<SyntaxToken<GeneralTokenType>> ConcealTokens(ILanguage language,
		IReadOnlyList<SyntaxToken<GeneralTokenType>> tokens,
		double revealedOffset, double revealedPercent)
	{
		return
		[
			..inner.ConcealTokens(language, tokens, revealedOffset, revealedPercent)
				.Select(token => new SyntaxToken<GeneralTokenType>
				{
					Value = $"{{{token.Type}}}{token.Value}",
					// Value = token.Value,
					Type = token.Type,
				}),
		];
	}
}
