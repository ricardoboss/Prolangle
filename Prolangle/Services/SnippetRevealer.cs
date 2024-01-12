using System.Text.RegularExpressions;

namespace Prolangle.Services;

public partial class SnippetRevealer(GuessGame guessGame, string sourceCode)
{
	private double RevealedProgress { get; set; } = 0.0;

	public string RevealMore()
	{
		RevealedProgress += 0.1;

		// replace all non-whitespaces with a bullet
		var concealedCode = NonWhitespaceRegex().Replace(sourceCode, "•");

		// reveal RevealedProgress % from the middle of the snippet using the original source code
		var revealStart = (int)(concealedCode.Length / 2f - concealedCode.Length * RevealedProgress / 2);
		var revealEnd = (int)(concealedCode.Length / 2f + concealedCode.Length * RevealedProgress / 2);

		// // randomly move the center of revealed code around a little, to make snippets harder to remember
		// var random = new Random(guessGame.Seeder());
		// const int padding = 3;
		// var jitter = random.Next((revealStart - padding) * -1, revealStart - padding);
		//
		// revealStart += jitter;
		// revealEnd += jitter;

		concealedCode = concealedCode[..revealStart] + sourceCode.Substring(revealStart, revealEnd - revealStart) +
		             concealedCode[revealEnd..];

		return concealedCode;
	}

	public void Win() => RevealedProgress = 1.0;

	[GeneratedRegex(@"\S")]
	private static partial Regex NonWhitespaceRegex();
}
