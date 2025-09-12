using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class SmalltalkTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly SmalltalkTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		// whitespace + comments
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"""[^""]*"""), GeneralTokenType.Comment);

		// literals
		yield return (new(@"'([^']|'')*'"), GeneralTokenType.Text); // string literal
		yield return (new(@"\d+r[0-9A-Za-z]+"), GeneralTokenType.Number); // radix number
		yield return (new(@"\d+\.\d+"), GeneralTokenType.Number); // float
		yield return (new(@"\d+"), GeneralTokenType.Number); // int

		// reserved keywords
		yield return (new(@"\b(self|super|nil|true|false|thisContext)\b"), GeneralTokenType.Keyword);

		// keyword selectors (end with :)
		yield return (new(@"[a-zA-Z_]\w*:"), GeneralTokenType.Keyword);

		// identifiers (variables, classes)
		yield return (new(@"[A-Z][A-Za-z0-9_]*"), GeneralTokenType.Identifier); // class/global
		yield return (new(@"[a-z][A-Za-z0-9_]*"), GeneralTokenType.Identifier); // var/temp

		// operators / binary selectors
		yield return (new(@"[\+\-\*/=~<>|&!?,@:\^\[\]]+"), GeneralTokenType.Operator);

		// punctuation
		yield return (new(@"[(){}\.\;\^]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
