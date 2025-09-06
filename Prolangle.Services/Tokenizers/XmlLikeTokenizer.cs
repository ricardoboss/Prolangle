using System.Xml.Linq;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tokenizers;

public class XmlLikeTokenizer : ITokenizer<GeneralTokenType>
{
	public static readonly XmlLikeTokenizer Instance = new();

	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		var doc = XDocument.Parse(code);

		return [..EmitTokens(doc, 0)];
	}

	private static IEnumerable<SyntaxToken<GeneralTokenType>> EmitTokens(XObject obj, int indent)
	{
		const char indentChar = ' ';
		const int indentPerLayer = 4;

		switch (obj)
		{
			case XDocument d:
				foreach (var subNode in d.Nodes())
					foreach (var subToken in EmitTokens(subNode, 0))
						yield return subToken;
				break;
			case XElement e:
				yield return new() { Value = new(indentChar, indent), Type = GeneralTokenType.Whitespace };
				yield return new() { Value = "<", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = e.Name.ToString(), Type = GeneralTokenType.Identifier };
				foreach (var attr in e.Attributes())
				{
					yield return new() { Value = " ", Type = GeneralTokenType.Whitespace };
					foreach (var subToken in EmitTokens(attr, 0))
						yield return subToken;
				}
				yield return new() { Value = ">", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = "\r\n", Type = GeneralTokenType.Whitespace };
				foreach (var subNode in e.Nodes())
					foreach (var subToken in EmitTokens(subNode, indent + indentPerLayer))
						yield return subToken;
				yield return new() { Value = new(indentChar, indent), Type = GeneralTokenType.Whitespace };
				yield return new() { Value = "</", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = e.Name.ToString(), Type = GeneralTokenType.Identifier };
				yield return new() { Value = ">", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = "\r\n", Type = GeneralTokenType.Whitespace };
				break;
			case XAttribute a:
				yield return new() { Value = a.Name.ToString(), Type = GeneralTokenType.Identifier };
				yield return new() { Value = "=", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = "\"", Type = GeneralTokenType.Punctuation };
				yield return new() { Value = a.Value, Type = GeneralTokenType.Text };
				yield return new() { Value = "\"", Type = GeneralTokenType.Punctuation };
				break;
			case XText t:
				yield return new() { Value = new(indentChar, indent), Type = GeneralTokenType.Whitespace };
				yield return new() { Value = t.Value, Type = GeneralTokenType.Text };
				yield return new() { Value = "\r\n", Type = GeneralTokenType.Whitespace };
				break;
			default:
				yield return new() { Value = obj.GetType().ToString(), Type = GeneralTokenType.Unknown };
				break;
		}
	}
}
