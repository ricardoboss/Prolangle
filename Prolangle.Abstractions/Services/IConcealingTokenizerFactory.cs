using Blism;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public interface IConcealingTokenizerFactory
{
	ITokenizer<GeneralTokenType> GetTokenizer(ILanguage language, double revealedOffset, double revealedPercent, bool debug);
}
