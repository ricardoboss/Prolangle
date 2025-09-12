using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class GraphQlTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly GraphQlTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"#.*", RegexOptions.Multiline), GeneralTokenType.Comment);
		yield return (new(@"""{3}[\s\S]*?""{3}"), GeneralTokenType.Text);
		yield return (new(@"""(?:\\.|[^""\\])*"""), GeneralTokenType.Text);
		yield return (new(@"-?(?:0|[1-9][0-9]*)(?:\.[0-9]+)?(?:[eE][+-]?[0-9]+)?"), GeneralTokenType.Number);
		yield return (new(@"\b(query|mutation|subscription|fragment|on|true|false|null)\b"), GeneralTokenType.Keyword);
		yield return (new(@"[_A-Za-z][_0-9A-Za-z]*"), GeneralTokenType.Identifier);
		yield return (new(@"\.\.\.|:|=|@|\$|&|\|"), GeneralTokenType.Operator);
		yield return (new(@"[{}()\[\],]"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
