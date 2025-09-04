using Blism;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

internal sealed class DefaultConcealingTokenizerFactory(ICodeConcealer concealer, ICodeTokenizer fallbackTokenizer)
	: IConcealingTokenizerFactory
{
	public ITokenizer<GeneralTokenType> GetTokenizer(ILanguage language, double revealedPercent) =>
		new ConcealingTokenizer(concealer, new GeneralTokenizer(language, fallbackTokenizer), language,
			revealedPercent);

	private sealed class ConcealingTokenizer(
		ICodeConcealer concealer,
		ITokenizer<GeneralTokenType> inner,
		ILanguage language,
		double revealedPercent) : ITokenizer<GeneralTokenType>
	{
		public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
		{
			var tokens = inner.Tokenize(code).ToList();

			var concealed = concealer.ConcealTokens(language, tokens, 0.5, revealedPercent);

			return concealed;
		}
	}
}

internal static class DefaultConcealingTokenizerFactoryServiceCollectionExtensions
{
	public static IServiceCollection AddDefaultConcealingTokenizerFactory(this IServiceCollection services)
	{
		services.AddSingleton<IConcealingTokenizerFactory, DefaultConcealingTokenizerFactory>();

		return services;
	}
}
