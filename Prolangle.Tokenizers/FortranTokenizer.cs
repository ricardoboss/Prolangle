using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class FortranTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly FortranTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"!.*", RegexOptions.Multiline), GeneralTokenType.Comment);
		yield return (new(@"^[cC\*].*", RegexOptions.Multiline), GeneralTokenType.Comment);
		yield return (new(@"'[^']*'|""[^""]*"""), GeneralTokenType.Text);
		yield return (new(@"\d+(\.\d+)?([eEdD][+-]?\d+)?"), GeneralTokenType.Number);
		yield return (new(@"\b(PROGRAM|SUBROUTINE|FUNCTION|IMPLICIT|NONE|INTEGER|REAL|DOUBLE|PRECISION|COMPLEX|CHARACTER|LOGICAL|IF|ELSE|ENDIF|DO|ENDDO|STOP|CALL|RETURN|MODULE|USE|INTERFACE|END|WRITE|READ|PRINT|PARAMETER)\b", RegexOptions.IgnoreCase), GeneralTokenType.Keyword);
		yield return (new(@"[A-Za-z][A-Za-z0-9_]*"), GeneralTokenType.Identifier);
		yield return (new(@"\.EQ\.|\.NE\.|\.LT\.|\.GT\.|\.LE\.|\.GE\.|\+|\-|\*|/|=|>|<"), GeneralTokenType.Operator);
		yield return (new(@"[(),;:]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
