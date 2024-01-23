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

	public static IEnumerable<object[]> TestData
	{
		get
		{
			yield return
			[
				"Console.WriteLine(message);",
				"••••••••••••eL•••••••••••••",
				"••••••••••iteLin•••••••••••",
				"•••••••••riteLine••••••••••",
				"••••••••WriteLine(•••••••••",
				"••••••e.WriteLine(me•••••••",
				"•••••le.WriteLine(mes••••••",
				"••••ole.WriteLine(mess•••••",
				"••nsole.WriteLine(messag•••",
				"•onsole.WriteLine(message••"
			];
		}
	}

	[Theory]
	[MemberData(nameof(TestData))]
	public void Test(string input,
		string expected10PercentOutput,
		string expected20PercentOutput,
		string expected30PercentOutput,
		string expected40PercentOutput,
		string expected50PercentOutput,
		string expected60PercentOutput,
		string expected70PercentOutput,
		string expected80PercentOutput,
		string expected90PercentOutput)
	{
		var seeder = new GameSeeder(() => 1_234, DateTime.MinValue, DateTime.MinValue);
		var snippetProvider = new LanguageSnippetProvider(seeder);
		var revealer = new SnippetRevealer(seeder, input, useJitter: false);

		Assert.Equal(expected10PercentOutput, revealer.RevealMore());
		Assert.Equal(expected20PercentOutput, revealer.RevealMore());
		Assert.Equal(expected30PercentOutput, revealer.RevealMore());
		Assert.Equal(expected40PercentOutput, revealer.RevealMore());
		Assert.Equal(expected50PercentOutput, revealer.RevealMore());
		Assert.Equal(expected60PercentOutput, revealer.RevealMore());
		Assert.Equal(expected70PercentOutput, revealer.RevealMore());
		Assert.Equal(expected80PercentOutput, revealer.RevealMore());
		Assert.Equal(expected90PercentOutput, revealer.RevealMore());
	}

	public static IEnumerable<object[]> TestDataWithJitter
	{
		get
		{
			yield return
			[
				"Console.WriteLine(message);",
				"••••••••••it•••••••••••••••",
				"••••••••WriteL•••••••••••••",
				"•••••••.WriteLi••••••••••••",
				"••••••e.WriteLin•••••••••••",
				"•••••le.WriteLine(m••••••••",
				"••••ole.WriteLine(me•••••••",
				"•••sole.WriteLine(mes••••••",
				"•onsole.WriteLine(messa••••",
				"Console.WriteLine(messag•••"
			];
		}
	}

	[Theory]
	[MemberData(nameof(TestDataWithJitter))]
	public void TestWithJitter(string input,
		string expected10PercentOutput,
		string expected20PercentOutput,
		string expected30PercentOutput,
		string expected40PercentOutput,
		string expected50PercentOutput,
		string expected60PercentOutput,
		string expected70PercentOutput,
		string expected80PercentOutput,
		string expected90PercentOutput)
	{
		var seeder = new GameSeeder(() => 1_234, DateTime.MinValue, DateTime.MinValue);
		var snippetProvider = new LanguageSnippetProvider(seeder);
		var revealer = new SnippetRevealer(seeder, input, useJitter: true);

		Assert.Equal(expected10PercentOutput, revealer.RevealMore());
		Assert.Equal(expected20PercentOutput, revealer.RevealMore());
		Assert.Equal(expected30PercentOutput, revealer.RevealMore());
		Assert.Equal(expected40PercentOutput, revealer.RevealMore());
		Assert.Equal(expected50PercentOutput, revealer.RevealMore());
		Assert.Equal(expected60PercentOutput, revealer.RevealMore());
		Assert.Equal(expected70PercentOutput, revealer.RevealMore());
		Assert.Equal(expected80PercentOutput, revealer.RevealMore());
		Assert.Equal(expected90PercentOutput, revealer.RevealMore());
	}
}
