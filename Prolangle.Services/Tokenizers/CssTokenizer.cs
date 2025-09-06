using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tokenizers;

public class CssTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly CssTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"[\w-]+(?=:)"), GeneralTokenType.Keyword);
		yield return (new(@"\d+(\.\d+)"), GeneralTokenType.Number);
		yield return (new(@"\b[:;{}@()]\b"), GeneralTokenType.Punctuation);
		yield return (new(@"(?<=:)[\w\s-()]+(?={)"), GeneralTokenType.Keyword);
		yield return (new(@"/\*[.\n\r]*\*/"), GeneralTokenType.Comment);
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
