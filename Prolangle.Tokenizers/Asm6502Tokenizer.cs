using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class Asm6502Tokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly Asm6502Tokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@";.*"), GeneralTokenType.Comment);
		yield return (new(@"\.(org|word|byte|db|dw|section|equ|global)\b"), GeneralTokenType.Keyword); // directives as keywords
		yield return (new(@"\b(lda|sta|jmp|ror|inc|dec|adc|sbc|cmp|and|or|eor|asl|lsr|rol|rti|jsr|rts|bit|nop|tax|txa|tay|tya|tsx|txs|pha|pla|php|plp)\b"), GeneralTokenType.Keyword);
		yield return (new(@"\$[0-9A-Fa-f]+|[0-9]+"), GeneralTokenType.Number);
		yield return (new(@"[A-Za-z_][A-Za-z0-9_]*"), GeneralTokenType.Identifier);
		yield return (new(@"#"), GeneralTokenType.Operator);
		yield return (new(@"[:,()]"), GeneralTokenType.Punctuation);
		yield return (new(@"""(?:\\.|[^""\\])*"""), GeneralTokenType.Text);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
