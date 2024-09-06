using Prolangle.Languages.Framework;
using Prolangle.Services;
using Weighted_Randomizer;

namespace Prolangle.Extensions;

public static class LanguageEnumerablePickExtensions
{
	public static ILanguage PickWeightedRandom(this IReadOnlyList<ILanguage> languages,
		GameSeeder seeder)
	{
		var randomizer = new StaticWeightedRandomizer<ILanguage>(seeder.Seeder());

		foreach (ILanguage language in languages)
			randomizer.Add(language,
				GetWeightFromTiobeRating(language.TiobeRating, languages.Select(l => l.TiobeRating)));

		return randomizer.NextWithReplacement();
	}

	/// <summary>
	/// We weigh a language's TIOBE rating against the frequency in
	/// which the language should appear. I.e., _more commonly_-used
	/// languages become the language to guess _less_ often.
	/// </summary>
	internal static int GetWeightFromTiobeRating(double? tiobeRating, IEnumerable<double?> allRatings)
	{
		var normalizedRatings = allRatings.Select(NormalizeToo100);

		if (tiobeRating is null or 0)
			return 100;

		var scaleFactor = 99.0 / normalizedRatings.Max();

		return (int)Math.Min(100.0 / (tiobeRating.Value * scaleFactor), 99.0);

		static double NormalizeToo100(double? input)
			=> input is null or 0 ? 100.0 : input.Value;
	}
}
