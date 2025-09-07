using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers.Tests;

public static class SingleCharacterTokenizerTest
{
	[Fact]
	public static void TestTokenizeSimpleString()
	{
		const string sourceCode = "Hello, World!";

		var tokenizer = new SingleCharacterTokenizer();

		var tokens = tokenizer.Tokenize(sourceCode).ToList();

		Assert.Equal(13, tokens.Count);

		Assert.Equal("H", tokens[0].Value);
		Assert.Equal(GeneralTokenType.Unknown, tokens[0].Type);

		Assert.Equal("e", tokens[1].Value);
		Assert.Equal(GeneralTokenType.Unknown, tokens[1].Type);

		Assert.Equal("d", tokens[^2].Value);
		Assert.Equal(GeneralTokenType.Unknown, tokens[^2].Type);

		Assert.Equal("!", tokens[^1].Value);
		Assert.Equal(GeneralTokenType.Unknown, tokens[^1].Type);
	}
}
