using Blism;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public interface IConcealingTokenizerFactory
{
	ITokenizer<GeneralTokenType> GetConcealedTokenizer(ILanguage language, ITokenizer<GeneralTokenType>? tokenizer,
		double revealedOffset, double revealedPercent, bool debug);
}
