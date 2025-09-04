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

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode).ToList();

		Assert.Equal(5, tokens.Count);

		Assert.Equal("Hello", tokens[0].Value);
		Assert.Equal(GeneralTokenType.Identifier, tokens[0].Type);

		Assert.Equal(",", tokens[1].Value);
		Assert.Equal(GeneralTokenType.Punctuation, tokens[1].Type);

		Assert.Equal(" ", tokens[2].Value);
		Assert.Equal(GeneralTokenType.Whitespace, tokens[2].Type);

		Assert.Equal("World", tokens[3].Value);
		Assert.Equal(GeneralTokenType.Identifier, tokens[3].Type);

		Assert.Equal("!", tokens[4].Value);
		Assert.Equal(GeneralTokenType.Operator, tokens[4].Type);
	}

	[Fact]
	public static void TestAggregatesWhitespaceIntoASingleToken()
	{
		const string sourceCode = "A B  C \n D";

		var languageMock = new Mock<ILanguage>();

		var tokenizer = new GeneralPurposeCodeTokenizer();

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode).ToList();

		Assert.Equal(7, tokens.Count);

		Assert.Equal("A", tokens[0].Value);
		Assert.Equal(" ", tokens[1].Value);
		Assert.Equal(GeneralTokenType.Whitespace, tokens[1].Type);
		Assert.Equal("B", tokens[2].Value);
		Assert.Equal("  ", tokens[3].Value);
		Assert.Equal(GeneralTokenType.Whitespace, tokens[3].Type);
		Assert.Equal("C", tokens[4].Value);
		Assert.Equal(" \n ", tokens[5].Value);
		Assert.Equal(GeneralTokenType.Whitespace, tokens[5].Type);
		Assert.Equal("D", tokens[6].Value);
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

		var tokens = tokenizer.Tokenize(languageMock.Object, sourceCode).ToList();

		Assert.Equal(49, tokens.Count);
		Assert.Multiple(() =>
		{
			Assert.Equal(17, tokens.Count(t => t.Type == GeneralTokenType.Whitespace));
			Assert.Equal(14, tokens.Count(t => t.Type == GeneralTokenType.Punctuation));
			Assert.Equal(1, tokens.Count(t => t.Type == GeneralTokenType.Text));
			Assert.Equal(15, tokens.Count(t => t.Type == GeneralTokenType.Identifier));
			Assert.Equal(0, tokens.Count(t => t.Type == GeneralTokenType.Operator));
			Assert.Equal(1, tokens.Count(t => t.Type == GeneralTokenType.Comment));
			Assert.Equal(0, tokens.Count(t => t.Type == GeneralTokenType.Keyword));
			Assert.Equal(0, tokens.Count(t => t.Type == GeneralTokenType.Number));
			Assert.Equal(1, tokens.Count(t => t.Type == GeneralTokenType.Unknown));
		});
	}
}
