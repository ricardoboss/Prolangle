using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class CssTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly CssTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"/\*[^*]*\*+(?:[^/*][^*]*\*+)*/"), GeneralTokenType.Comment);
		yield return (new(@"""(?:\\.|[^""\\])*""|^'(?:\\.|[^'\\])*'"), GeneralTokenType.Text);
		yield return (new(@"[0-9]*\.[0-9]+(?:[a-zA-Z%]+)?|[0-9]+(?:[a-zA-Z%]+)?"), GeneralTokenType.Number);
		yield return (new(@"@(import|media|keyframes|supports|page|font-face)\b|^!important\b"), GeneralTokenType.Keyword);
		yield return (new(@"-?[_a-zA-Z][_a-zA-Z0-9-]*"), GeneralTokenType.Identifier);
		yield return (new(@"(~=|\|=|\^=|\$=|\*=|=|:)"), GeneralTokenType.Operator);
		yield return (new(@"[{}();,\.]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
