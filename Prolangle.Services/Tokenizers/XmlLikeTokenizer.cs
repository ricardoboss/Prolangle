using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tokenizers;

public class XmlLikeTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly XmlLikeTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"<\?[^>]+>"), GeneralTokenType.Keyword);
		yield return (new("</[^>]+>"), GeneralTokenType.Identifier);
		yield return (new("<[^>]+>"), GeneralTokenType.Identifier);
		yield return (new(@"(?<=\>).+(?=</)"), GeneralTokenType.Unknown);
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
