using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tokenizers;

public class XmlLikeTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly XmlLikeTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"<!--(?:.|\n)*?-->"), GeneralTokenType.Comment);
		yield return (new(@"<!\[CDATA\[(?:.|\n)*?\]\]>"), GeneralTokenType.Keyword);
		yield return (new(@"<!DOCTYPE\b[^>]*>"), GeneralTokenType.Keyword);
		yield return (new(@"<\?.*?\?>"), GeneralTokenType.Keyword);

		// attribute values
		yield return (new(@"""(?:\\.|[^""\\])*""|'(?:\\.|[^'\\])*'"), GeneralTokenType.Text);

		// text nodes between tags
		yield return (new(@"(?<=>)[^<>]+(?=<)"), GeneralTokenType.Text);

		// element/closing tag names
		yield return (new(@"(?<=</?)[A-Za-z_:][A-Za-z0-9.\-_:]*"), GeneralTokenType.Identifier);

		// attribute names
		yield return (new(@"(?<=\s)[A-Za-z_:][A-Za-z0-9.\-_:]*(?=\s*=)"), GeneralTokenType.Identifier);

		yield return (new(@"="), GeneralTokenType.Operator);
		yield return (new(@"</|/>|<|>"), GeneralTokenType.Punctuation);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
