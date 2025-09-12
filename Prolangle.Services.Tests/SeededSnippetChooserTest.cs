using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services.Tests;

public static class SeededSnippetChooserTest
{
	[Fact]
	public static void TestHappyPath()
	{
		var gameSeedProviderMock = new Mock<IGameSeedProvider>();
		var snippetsProviderMock = new Mock<ISnippetsProvider>();
		var firstLanguageMock = new Mock<ILanguage>();
		var secondLanguageMock = new Mock<ILanguage>();
		var firstSnippetMock = new Mock<ICodeSnippet>();
		var secondSnippetMock = new Mock<ICodeSnippet>();
		var seed = GameSeed.From(1337);

		snippetsProviderMock
			.Setup(p => p.GetAvailableLanguages())
			.Returns([firstLanguageMock.Object, secondLanguageMock.Object])
			.Verifiable();

		gameSeedProviderMock
			.Setup(p => p.GetCurrentGameSeed())
			.Returns(seed)
			.Verifiable();

		ILanguage? chosenLanguage = null;
		snippetsProviderMock
			.Setup(p => p.GetAllForLanguage(It.IsAny<ILanguage>()))
			.Callback<ILanguage>(l => chosenLanguage = l)
			.Returns([firstSnippetMock.Object, secondSnippetMock.Object])
			.Verifiable();

		var chooser = new SeededSnippetChooser(gameSeedProviderMock.Object, snippetsProviderMock.Object);
		var snippet = chooser.ChooseSnippet();

		Assert.Equal(secondLanguageMock.Object, chosenLanguage);
		Assert.Equal(secondSnippetMock.Object, snippet);

		gameSeedProviderMock.VerifyAll();
		snippetsProviderMock.VerifyAll();
		firstLanguageMock.VerifyAll();
		secondLanguageMock.VerifyAll();
		firstSnippetMock.VerifyAll();
		secondSnippetMock.VerifyAll();
	}
}
