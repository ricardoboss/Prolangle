using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services.Tests;

public static class SimpleCodeConcealerTest
{
	[Fact]
	public static void TestNothingRevealed()
	{
		CodeToken[] tokens = [
			new(0, "Hello", TokenType.Other),
			new(5, ", ", TokenType.Other),
			new(7, "World", TokenType.Other),
			new(12, "!", TokenType.Other),
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new SimpleCodeConcealer();

		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0, 0);

		Assert.Equal(4, concealedTokens.Count);
		Assert.All(concealedTokens, t =>
		{
			Assert.Equal(CodeTokenVisibility.Concealed, t.Visibility);
		});
	}

	[Fact]
	public static void TestMiddleRevealed()
	{
		CodeToken[] tokens = [
			new(0, "Hello", TokenType.Other),
			new(5, ", ", TokenType.Other),
			new(7, "World", TokenType.Other),
			new(12, "!", TokenType.Other),
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new SimpleCodeConcealer();

		// start in the middle
		// reveal 50% overall
		// => "*****, World*"
		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0.5, 0.5);

		Assert.Equal(4, concealedTokens.Count);
		Assert.Equal(CodeTokenVisibility.Concealed, concealedTokens[0].Visibility);
		Assert.Equal(CodeTokenVisibility.Visible, concealedTokens[1].Visibility);
		Assert.Equal(CodeTokenVisibility.Visible, concealedTokens[2].Visibility);
		Assert.Equal(CodeTokenVisibility.Concealed, concealedTokens[3].Visibility);
	}

	[Fact]
	public static void TestStartRevealed()
	{
		CodeToken[] tokens = [
			new(0, "Hello", TokenType.Other),
			new(5, ", ", TokenType.Other),
			new(7, "World", TokenType.Other),
			new(12, "!", TokenType.Other),
		];

		var languageMock = new Mock<ILanguage>();

		var concealer = new SimpleCodeConcealer();

		var concealedTokens = concealer.ConcealTokens(languageMock.Object, tokens, 0, 0.5);

		Assert.Equal(4, concealedTokens.Count);
		Assert.Equal(CodeTokenVisibility.Visible, concealedTokens[0].Visibility);
		Assert.Equal(CodeTokenVisibility.Visible, concealedTokens[1].Visibility);
		Assert.Equal(CodeTokenVisibility.Concealed, concealedTokens[2].Visibility);
		Assert.Equal(CodeTokenVisibility.Concealed, concealedTokens[3].Visibility);
	}
}
