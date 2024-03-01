using Prolangle.Languages.Framework;
using Prolangle.Services;
using Weighted_Randomizer;

namespace Prolangle.Extensions;

public static class LanguageEnumerablePickExtensions
{
	public static ILanguage PickWeightedRandom(this IEnumerable<ILanguage> languages,
		GameSeeder seeder)
	{
		var randomizer = new StaticWeightedRandomizer<ILanguage>();

		foreach (ILanguage language in languages)
		{
			// we weigh a language's TIOBE rating against frequency in
			// which the language should appear
			var weight = language.TiobeRating is null or 0 ? 100 : 100 / language.TiobeRating;

			randomizer.Add(language, (int)weight);
		}

		return randomizer.NextWithReplacement();
	}
}
