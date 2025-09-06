using Blism;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tests;

public static class TokenBasedCodeConcealerTest
{
	[Fact]
	public static void TestNothingRevealed()
	{
		SyntaxToken<GeneralTokenType>[] tokens =
		[
			new() { Value = "Hello", Type = GeneralTokenType.Unknown },
			new() { Value = ", ", Type = GeneralTokenType.Unknown },
			new() { Value = "World", Type = GeneralTokenType.Unknown },
			new() { Value = "!", Type = GeneralTokenType.Unknown },
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new TokenBasedCodeConcealer();

		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0, 0);

		Assert.Equal(4, concealedTokens.Count);

		var text = string.Join("", concealedTokens.Select(t => t.Value));
		Assert.Equal("•••••••••••••", text);
	}

	[Fact]
	public static void TestMiddleRevealed()
	{
		SyntaxToken<GeneralTokenType>[] tokens =
		[
			new() { Value = "Hello", Type = GeneralTokenType.Unknown },
			new() { Value = ", ", Type = GeneralTokenType.Unknown },
			new() { Value = "World", Type = GeneralTokenType.Unknown },
			new() { Value = "!", Type = GeneralTokenType.Unknown },
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new TokenBasedCodeConcealer();

		// start in the middle
		// reveal 50% overall
		// => "*****, World*"
		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0.5, 0.5);

		Assert.Equal(4, concealedTokens.Count);

		var text = string.Join("", concealedTokens.Select(t => t.Value));
		Assert.Equal("•••••, World•", text);
	}

	[Fact]
	public static void TestStartRevealed()
	{
		SyntaxToken<GeneralTokenType>[] tokens =
		[
			new() { Value = "Hello", Type = GeneralTokenType.Unknown },
			new() { Value = ", ", Type = GeneralTokenType.Unknown },
			new() { Value = "World", Type = GeneralTokenType.Unknown },
			new() { Value = "!", Type = GeneralTokenType.Unknown },
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new TokenBasedCodeConcealer();

		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0, 0.5);

		Assert.Equal(4, concealedTokens.Count);

		var text = string.Join("", concealedTokens.Select(t => t.Value));
		Assert.Equal("Hello, ••••••", text);
	}
}
