using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class CobolTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly CobolTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"^\*.*", RegexOptions.Multiline), GeneralTokenType.Comment);
		yield return (new(@"\*\>.*", RegexOptions.Multiline), GeneralTokenType.Comment);
		yield return (new(@"'[^']*'|""[^""]*"""), GeneralTokenType.Text);
		yield return (new(@"\d+(\.\d+)?"), GeneralTokenType.Number);
		yield return (new(@"\b(IDENTIFICATION|DIVISION|PROGRAM-ID|ENVIRONMENT|DATA|PROCEDURE|SECTION|MOVE|ADD|SUBTRACT|MULTIPLY|DIVIDE|COMPUTE|PERFORM|UNTIL|VARYING|IF|ELSE|END-IF|DISPLAY|STOP|RUN)\b", RegexOptions.IgnoreCase), GeneralTokenType.Keyword);
		yield return (new(@"[A-Z][A-Z0-9-]*", RegexOptions.IgnoreCase), GeneralTokenType.Identifier);
		yield return (new(@"(\+|\-|\*|/|=|>=|<=|<>|>|<)"), GeneralTokenType.Operator);
		yield return (new(@"[.,();:]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
