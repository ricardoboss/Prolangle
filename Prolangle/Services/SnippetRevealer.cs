using System.Text.RegularExpressions;

namespace Prolangle.Services;

/// <param name="gameSeeder">The seed source for jitter.</param>
/// <param name="sourceCode">The source code to conceal and subsequently reveal.</param>
/// <param name="useJitter">Whether to introduce random shift, rather than always reveal code from the same center.</param>
public partial class SnippetRevealer(GameSeeder gameSeeder, string sourceCode, bool useJitter)
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

		if (useJitter)
		{
			// randomly move the center of revealed code around a little, to make snippets harder to remember
			var random = new Random(gameSeeder.Seeder());
			const int padding = 3;
			int shiftedStart = revealStart - padding > 0 ? revealStart - padding : revealStart;
			var jitter = random.Next(shiftedStart * -1, shiftedStart);

			revealStart += jitter;
			revealEnd += jitter;
		}

		concealedCode = concealedCode[..revealStart] + sourceCode.Substring(revealStart, revealEnd - revealStart) +
		                concealedCode[revealEnd..];

		return concealedCode;
	}

	public void Win() => RevealedProgress = 1.0;

	[GeneratedRegex(@"\S")]
	private static partial Regex NonWhitespaceRegex();
}
