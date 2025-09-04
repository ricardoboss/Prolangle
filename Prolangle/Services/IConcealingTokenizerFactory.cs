using Blism;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

internal interface IConcealingTokenizerFactory
{
	ITokenizer<GeneralTokenType> GetTokenizer(ILanguage language, double revealedPercent);
}
