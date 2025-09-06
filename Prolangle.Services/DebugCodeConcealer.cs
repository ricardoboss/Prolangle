using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class DebugCodeConcealer : ICodeConcealer
{
	public IReadOnlyList<SyntaxToken<GeneralTokenType>> ConcealTokens(ILanguage language,
		IReadOnlyList<SyntaxToken<GeneralTokenType>> tokens,
		double revealedOffset, double revealedPercent)
	{
		return
		[
			..tokens.Select(token => new SyntaxToken<GeneralTokenType>
			{
				// Value = $"{{{token.Type}}}{token.Value}",
				Value = token.Value,
				Type = token.Type,
			}),
		];
	}
}

public static class DebugCodeConcealerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDebugCodeConcealer(this IServiceCollection services)
	{
		services.AddSingleton<ICodeConcealer, DebugCodeConcealer>();

		return services;
	}
}
