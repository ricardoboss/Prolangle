using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tests;

public static class GeneralPurposeCodeTokenizerTest
{
	[Fact]
	public static void TestTokenizeSimpleString()
	{
		const string sourceCode = "Hello, World!";

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new GeneralPurposeCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode);

		Assert.Equal(5, tokens.Count);

		Assert.Equal("Hello", tokens[0].Text);
		Assert.Equal(0, tokens[0].StartIndex);
		Assert.Equal(TokenType.Identifier, tokens[0].Type);

		Assert.Equal(",", tokens[1].Text);
		Assert.Equal(5, tokens[1].StartIndex);
		Assert.Equal(TokenType.Punctuation, tokens[1].Type);

		Assert.Equal(" ", tokens[2].Text);
		Assert.Equal(6, tokens[2].StartIndex);
		Assert.Equal(TokenType.Whitespace, tokens[2].Type);

		Assert.Equal("World", tokens[3].Text);
		Assert.Equal(7, tokens[3].StartIndex);
		Assert.Equal(TokenType.Identifier, tokens[3].Type);

		Assert.Equal("!", tokens[4].Text);
		Assert.Equal(12, tokens[4].StartIndex);
		Assert.Equal(TokenType.Operator, tokens[4].Type);
	}

	[Fact]
	public static void TestAggregatesWhitespaceIntoASingleToken()
	{
		const string sourceCode = "A B  C \n D";

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new GeneralPurposeCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode);

		Assert.Equal(7, tokens.Count);

		Assert.Equal("A", tokens[0].Text);
		Assert.Equal(0, tokens[0].StartIndex);
		Assert.Equal(" ", tokens[1].Text);
		Assert.Equal(1, tokens[1].StartIndex);
		Assert.Equal(TokenType.Whitespace, tokens[1].Type);
		Assert.Equal("B", tokens[2].Text);
		Assert.Equal(2, tokens[2].StartIndex);
		Assert.Equal("  ", tokens[3].Text);
		Assert.Equal(3, tokens[3].StartIndex);
		Assert.Equal(TokenType.Whitespace, tokens[3].Type);
		Assert.Equal("C", tokens[4].Text);
		Assert.Equal(5, tokens[4].StartIndex);
		Assert.Equal(" \n ", tokens[5].Text);
		Assert.Equal(6, tokens[5].StartIndex);
		Assert.Equal(TokenType.Whitespace, tokens[5].Type);
		Assert.Equal("D", tokens[6].Text);
		Assert.Equal(9, tokens[6].StartIndex);
	}

	[Fact]
	public static void TestTokenizesSimpleCSharpCode()
	{
		const string sourceCode = """
		                          using System;

		                          namespace MyApp;

		                          public class Program {
		                          	public static void Main(string[] args) {
		                          		// greet the first parameter
		                          		Console.WriteLine($"Hello, {args[0]}");
		                          	}
		                          }
		                          """;

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new GeneralPurposeCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode);

		Assert.Equal(49, tokens.Count);
		Assert.Multiple(() =>
		{
			Assert.Equal(17, tokens.Count(t => t.Type == TokenType.Whitespace));
			Assert.Equal(14, tokens.Count(t => t.Type == TokenType.Punctuation));
			Assert.Equal(1, tokens.Count(t => t.Type == TokenType.Text));
			Assert.Equal(15, tokens.Count(t => t.Type == TokenType.Identifier));
			Assert.Equal(0, tokens.Count(t => t.Type == TokenType.Operator));
			Assert.Equal(1, tokens.Count(t => t.Type == TokenType.Comment));
			Assert.Equal(0, tokens.Count(t => t.Type == TokenType.Keyword));
			Assert.Equal(0, tokens.Count(t => t.Type == TokenType.Number));
			Assert.Equal(1, tokens.Count(t => t.Type == TokenType.Other));
		});
	}
}
