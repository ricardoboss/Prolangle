using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tests;

public static class CharacterCodeTokenizerTest
{
	[Fact]
	public static void TestTokenizeSimpleString()
	{
		const string sourceCode = "Hello, World!";

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new CharacterCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode);

		Assert.Equal(13, tokens.Count);

		Assert.Equal("H", tokens[0].Text);
		Assert.Equal(0, tokens[0].StartIndex);
		Assert.Equal(TokenType.Other, tokens[0].Type);

		Assert.Equal("e", tokens[1].Text);
		Assert.Equal(1, tokens[1].StartIndex);
		Assert.Equal(TokenType.Other, tokens[1].Type);

		Assert.Equal("d", tokens[^2].Text);
		Assert.Equal(11, tokens[^2].StartIndex);
		Assert.Equal(TokenType.Other, tokens[^2].Type);

		Assert.Equal("!", tokens[^1].Text);
		Assert.Equal(12, tokens[^1].StartIndex);
		Assert.Equal(TokenType.Other, tokens[^1].Type);
	}
}
