using Blism;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Services.Tokenizers;

namespace Prolangle.Services;

public class DefaultConcealingTokenizerFactory(ICodeConcealer concealer, ICodeTokenizer fallbackTokenizer)
	: IConcealingTokenizerFactory
{
	public ITokenizer<GeneralTokenType>
		GetTokenizer(ILanguage language, double revealedOffset, double revealedPercent, bool debug) =>
		new ConcealingTokenizer(
			debug ? new DebugCodeConcealer(concealer) : concealer,
			new GeneralTokenizer(language, fallbackTokenizer),
			language,
			revealedOffset,
			revealedPercent
		);
}

public static class DefaultConcealingTokenizerFactoryServiceCollectionExtensions
{
	public static IServiceCollection AddDefaultConcealingTokenizerFactory(this IServiceCollection services)
	{
		services.AddSingleton<IConcealingTokenizerFactory, DefaultConcealingTokenizerFactory>();

		return services;
	}
}
