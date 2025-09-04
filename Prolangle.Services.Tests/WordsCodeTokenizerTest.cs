using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tests;

public static class WordsCodeTokenizerTest
{
	[Fact]
	public static void TestTokenizeSimpleString()
	{
		const string sourceCode = "Hello, World!";

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new WordsCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode);

		Assert.Equal(3, tokens.Count);

		Assert.Equal("Hello,", tokens[0].Text);
		Assert.Equal(0, tokens[0].StartIndex);
		Assert.Equal(TokenType.Other, tokens[0].Type);

		Assert.Equal(" ", tokens[1].Text);
		Assert.Equal(6, tokens[1].StartIndex);
		Assert.Equal(TokenType.Whitespace, tokens[1].Type);

		Assert.Equal("World!", tokens[^1].Text);
		Assert.Equal(7, tokens[^1].StartIndex);
		Assert.Equal(TokenType.Other, tokens[^1].Type);
	}
}
