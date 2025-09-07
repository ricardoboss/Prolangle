using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class AssemblyTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly AssemblyTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"[;#].*"), GeneralTokenType.Comment);
		yield return (new(@"0[xX][0-9A-Fa-f]+|[0-9]+[hHbB]?|[0-9]+"), GeneralTokenType.Number);
		yield return (new(@"""(?:\\.|[^""\\])*""|'(?:\\.|[^'\\])*'"), GeneralTokenType.Text);
		yield return (new(@"\b(mov|add|sub|jmp|cmp|push|pop|call|ret|db|dw|dd|section|global|extern)\b"), GeneralTokenType.Keyword);
		yield return (new(@"[A-Za-z_.$][A-Za-z0-9_.$]*"), GeneralTokenType.Identifier);
		yield return (new(@"[+\-*/%&|^~]"), GeneralTokenType.Operator);
		yield return (new(@"[:(),\[\]{}]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
