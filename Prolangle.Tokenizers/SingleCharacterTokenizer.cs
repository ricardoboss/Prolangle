using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

/// <summary>
/// Tokenizes any given code by interpreting each individual character as a token.
/// </summary>
public class SingleCharacterTokenizer : ITokenizer<GeneralTokenType>
{
	public static readonly SingleCharacterTokenizer Instance = new();

	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		return code.Select(c => new SyntaxToken<GeneralTokenType>
		{
			Value = c.ToString(),
			Type = GeneralTokenType.Unknown,
		});
	}
}
