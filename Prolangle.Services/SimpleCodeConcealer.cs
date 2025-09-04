using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

/// <summary>
/// Reveals code, regardless of language tokens, that is, without respecting the given languages syntax tokens. It might
/// reveal tokens only partially.
/// </summary>
public class SimpleCodeConcealer : ICodeConcealer
{
	public IReadOnlyList<ConcealableCodeToken> ConcealTokens(ILanguage language, IReadOnlyList<CodeToken> tokens,
		double revealedOffset, double revealedPercent)
	{
		var revealedAreaCenterIndex = tokens.Count * revealedOffset;
		var revealedAreaSize = tokens.Count * revealedPercent;
		var startRevealingAtIndex = revealedAreaCenterIndex - revealedAreaSize / 2;
		startRevealingAtIndex = Math.Max(0, startRevealingAtIndex);

		var endRevealingAtIndex = startRevealingAtIndex + revealedAreaSize;
		endRevealingAtIndex = Math.Min(tokens.Count, endRevealingAtIndex);

		return [..concealTokensIteratively()];

		IEnumerable<ConcealableCodeToken> concealTokensIteratively()
		{
			var tokenIdx = 0;
			foreach (var token in tokens)
			{
				if (tokenIdx < startRevealingAtIndex || tokenIdx >= endRevealingAtIndex)
					yield return ConcealableCodeToken.FromCodeToken(token, CodeTokenVisibility.Concealed);
				else
					yield return ConcealableCodeToken.FromCodeToken(token);

				tokenIdx++;
			}
		}
	}
}

public static class SimpleCodeConcealerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddSimpleCodeConcealer(this IServiceCollection services)
	{
		services.AddSingleton<ICodeConcealer, SimpleCodeConcealer>();

		return services;
	}
}
