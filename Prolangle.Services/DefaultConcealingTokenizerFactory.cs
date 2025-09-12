using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Tokenizers;

namespace Prolangle.Services;

public class DefaultConcealingTokenizerFactory(ICodeConcealer concealer, ITokenizer<GeneralTokenType> fallbackTokenizer)
	: IConcealingTokenizerFactory
{
	public ITokenizer<GeneralTokenType>
		GetConcealedTokenizer(ILanguage language, ITokenizer<GeneralTokenType>? tokenizer, double revealedOffset, double revealedPercent, bool debug) =>
		new ConcealingTokenizer(
			debug ? new DebugCodeConcealer(concealer) : concealer,
			tokenizer ?? new LanguageBasedTokenizer(language, fallbackTokenizer),
			language,
			revealedOffset,
			revealedPercent
		);
}

public static class DefaultConcealingTokenizerFactoryServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDefaultConcealingTokenizerFactory(this IServiceCollection services)
	{
		services.AddSingleton<IConcealingTokenizerFactory, DefaultConcealingTokenizerFactory>();

		return services;
	}
}
