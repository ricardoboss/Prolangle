using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Prolangle.Services;

namespace Prolangle.Tests;

public class SnippetRevealerTests
{
	public SnippetRevealerTests()
	{
		GuessGameLogger = NullLogger<GuessGame>.Instance;

		var environment = new Moq.Mock<IWebAssemblyHostEnvironment>();
		environment.SetupGet(e => e.Environment).Returns("Development");
		HostEnvironment = environment.Object;

		LanguagesProvider = new LanguagesProvider();
	}

	private ILogger<GuessGame> GuessGameLogger { get; }

	private IWebAssemblyHostEnvironment HostEnvironment { get; }
	private LanguagesProvider LanguagesProvider { get; }

	private const string VeryShortSnippet = "Console.WriteLine(message);";

	public static IEnumerable<object[]> VeryShortTestData
	{
		get
		{
			yield return
			[
				"•••••••••••teLin•••••••••••",
				"•••••••••••teLin•••••••••••",
				"•••••••••••teLin•••••••••••",
				"•••••••••••teLin•••••••••••",
				"••••••••••iteLin•••••••••••",
				"•••••••••riteLine••••••••••",
				"•••••••••riteLine••••••••••",
				"••••••••WriteLine(•••••••••",
				"•••••••.WriteLine(m••••••••",
			];
		}
	}

	[Theory]
	[MemberData(nameof(VeryShortTestData))]
	public void VeryShortTest(string expected3PercentOutput,
		string expected8PercentOutput,
		string expected13PercentOutput,
		string expected18PercentOutput,
		string expected23PercentOutput,
		string expected28PercentOutput,
		string expected33PercentOutput,
		string expected38PercentOutput,
		string expected43PercentOutput)
	{
		var seeder = new GameSeeder(() => 1_234, DateTime.MinValue, DateTime.MinValue);
		var snippetProvider = new LanguageSnippetProvider(seeder);
		var revealer = new SnippetRevealer(seeder, VeryShortSnippet, useJitter: false);

		Assert.Equal(expected3PercentOutput, revealer.RevealMore());
		Assert.Equal(expected8PercentOutput, revealer.RevealMore());
		Assert.Equal(expected13PercentOutput, revealer.RevealMore());
		Assert.Equal(expected18PercentOutput, revealer.RevealMore());
		Assert.Equal(expected23PercentOutput, revealer.RevealMore());
		Assert.Equal(expected28PercentOutput, revealer.RevealMore());
		Assert.Equal(expected33PercentOutput, revealer.RevealMore());
		Assert.Equal(expected38PercentOutput, revealer.RevealMore());
		Assert.Equal(expected43PercentOutput, revealer.RevealMore());
	}

	private const string Snippet = "Console.WriteLine(message); Console.WriteLine(anotherMessage);";

	public static IEnumerable<object[]> TestData
	{
		get
		{
			yield return
			[
				"••••••••••••••••••••••••••• Conso•••••••••••••••••••••••••••••",
				"••••••••••••••••••••••••••• Conso•••••••••••••••••••••••••••••",
				"••••••••••••••••••••••••••; Console•••••••••••••••••••••••••••",
				"•••••••••••••••••••••••••); Console.••••••••••••••••••••••••••",
				"•••••••••••••••••••••••ge); Console.Wr••••••••••••••••••••••••",
				"••••••••••••••••••••••age); Console.Wri•••••••••••••••••••••••",
				"••••••••••••••••••••ssage); Console.Write•••••••••••••••••••••",
				"•••••••••••••••••••essage); Console.WriteL••••••••••••••••••••",
				"•••••••••••••••••(message); Console.WriteLin••••••••••••••••••",
			];
		}
	}

	[Theory]
	[MemberData(nameof(TestData))]
	public void Test(string expected3PercentOutput,
					 string expected8PercentOutput,
					 string expected13PercentOutput,
					 string expected18PercentOutput,
					 string expected23PercentOutput,
					 string expected28PercentOutput,
					 string expected33PercentOutput,
					 string expected38PercentOutput,
					 string expected43PercentOutput)
	{
		var seeder = new GameSeeder(() => 1_234, DateTime.MinValue, DateTime.MinValue);
		var snippetProvider = new LanguageSnippetProvider(seeder);
		var revealer = new SnippetRevealer(seeder, Snippet, useJitter: false);

		Assert.Equal(expected3PercentOutput, revealer.RevealMore());
		Assert.Equal(expected8PercentOutput, revealer.RevealMore());
		Assert.Equal(expected13PercentOutput, revealer.RevealMore());
		Assert.Equal(expected18PercentOutput, revealer.RevealMore());
		Assert.Equal(expected23PercentOutput, revealer.RevealMore());
		Assert.Equal(expected28PercentOutput, revealer.RevealMore());
		Assert.Equal(expected33PercentOutput, revealer.RevealMore());
		Assert.Equal(expected38PercentOutput, revealer.RevealMore());
		Assert.Equal(expected43PercentOutput, revealer.RevealMore());
	}

	public static IEnumerable<object[]> TestDataWithJitter
	{
		get
		{
			yield return
			[
				"••••••••••••••••••••••age); ••••••••••••••••••••••••••••••••••",
				"••••••••••••••••••••••age); ••••••••••••••••••••••••••••••••••",
				"•••••••••••••••••••••sage); Co••••••••••••••••••••••••••••••••",
				"••••••••••••••••••••ssage); Con•••••••••••••••••••••••••••••••",
				"••••••••••••••••••message); Conso•••••••••••••••••••••••••••••",
				"••••••••••••••••••message); Console•••••••••••••••••••••••••••",
				"••••••••••••••••e(message); Console.W•••••••••••••••••••••••••",
				"•••••••••••••••ne(message); Console.Wr••••••••••••••••••••••••",
				"••••••••••••••ine(message); Console.Write•••••••••••••••••••••",
			];
		}
	}

	[Theory]
	[MemberData(nameof(TestDataWithJitter))]
	public void TestWithJitter(string expected3PercentOutput,
							   string expected8PercentOutput,
							   string expected13PercentOutput,
							   string expected18PercentOutput,
							   string expected23PercentOutput,
							   string expected28PercentOutput,
							   string expected33PercentOutput,
							   string expected38PercentOutput,
							   string expected43PercentOutput)
	{
		var seeder = new GameSeeder(() => 1_234, DateTime.MinValue, DateTime.MinValue);
		var snippetProvider = new LanguageSnippetProvider(seeder);
		var revealer = new SnippetRevealer(seeder, Snippet, useJitter: true);

		Assert.Equal(expected3PercentOutput, revealer.RevealMore());
		Assert.Equal(expected8PercentOutput, revealer.RevealMore());
		Assert.Equal(expected13PercentOutput, revealer.RevealMore());
		Assert.Equal(expected18PercentOutput, revealer.RevealMore());
		Assert.Equal(expected23PercentOutput, revealer.RevealMore());
		Assert.Equal(expected28PercentOutput, revealer.RevealMore());
		Assert.Equal(expected33PercentOutput, revealer.RevealMore());
		Assert.Equal(expected38PercentOutput, revealer.RevealMore());
		Assert.Equal(expected43PercentOutput, revealer.RevealMore());
	}
}
