using Prolangle.Services;

namespace Prolangle.Tests;

public class SnippetRevealerTests
{
	public static IEnumerable<object[]> SnippetData
	{
		get { yield return ["Console.WriteLine(message);",
							"•••••••••••teL•••••••••••••",
							"••••••••••iteLi••••••••••••",
							"••••••••WriteLine••••••••••",
							"•••••••.WriteLine(•••••••••",
							"••••••e.WriteLine(m••••••••",
							"••••ole.WriteLine(mes••••••",
							"•••sole.WriteLine(mess•••••",
							"••nsole.WriteLine(messa••••",
							"Console.WriteLine(message••"]; }
	}

	[Theory]
	[MemberData(nameof(SnippetData))]
	public void Test1(string input,
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
		var game = new GuessGame(null, () => DateTime.Now.Minute);
		var revealer = new SnippetRevealer(game, input);

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
