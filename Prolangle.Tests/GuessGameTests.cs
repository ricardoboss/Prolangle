using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Prolangle.Services;

namespace Prolangle.Tests;

public class GuessGameTests
{
	public GuessGameTests()
	{
		GuessGameLogger = NullLogger<GuessGame>.Instance;

		var environment = new Moq.Mock<IWebAssemblyHostEnvironment>();
		environment.SetupGet(e => e.Environment).Returns("Development");
		HostEnvironment = environment.Object;

		LanguagesProvider = new LanguagesProvider();
	}

	private NullLogger<GuessGame> GuessGameLogger { get; set; }

	private IWebAssemblyHostEnvironment HostEnvironment { get; set; }

	private LanguagesProvider LanguagesProvider { get; }

	[Theory]
	[InlineData(1_000, "STEP", "STEP")]
	[InlineData(1_001, "Objective-C", "C#")]
	[InlineData(1_234, "Pascal", "JavaScript")]
	public void TestLanguages(int seed, string expectedMetadatumGameLanguage, string expectedSnippetGameLanguage)
	{
		var seeder = new GameSeeder(() => seed, DateTime.MinValue, DateTime.MinValue);
		var languageSnippetProvider = new LanguageSnippetProvider(seeder);
		var game = new GuessGame(LanguagesProvider, languageSnippetProvider, GuessGameLogger, seeder, HostEnvironment);

		Assert.Equal(expectedMetadatumGameLanguage, game.MetadatumGameLanguage.Name);
		Assert.Equal(expectedSnippetGameLanguage, game.SnippetGameLanguage.Name);
	}
}
