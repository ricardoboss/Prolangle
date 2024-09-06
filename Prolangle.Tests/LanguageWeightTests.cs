using Prolangle.Extensions;
using Prolangle.Languages.Framework;
using Prolangle.Services;
using Weighted_Randomizer;

namespace Prolangle.Tests;

public class LanguageWeightTests
{
	/// <summary>
	/// Languages that don't have data
	/// </summary>
	public static IEnumerable<object?[]> NoData
	{
		get
		{
			List<double?> emptyData = [];

			yield return [null, 100, emptyData];

			yield return [0.0, 100, emptyData];
		}
	}

	/// <summary>
	/// Made-up language data
	/// </summary>
	public static IEnumerable<object?[]> FictionalData
	{
		get
		{
			double?[] ratings = [0.5, 1.0, 20.0];
			double?[] expectedWeights = [40, 20, 1];

			for (int i = 0; i < ratings.Length; i++)
				yield return [ratings[i], expectedWeights[i], ratings];
		}
	}

	/// <summary>
	/// Examples from our actual languages
	/// </summary>
	public static IEnumerable<object?[]> RealWorldData
	{
		get
		{
			// Dart, Rust, Assembly, JS, C
			double?[] ratings = [0.47, 0.79, 1.11, 2.9, 11.44];
			double?[] expectedWeights = [24, 14, 10, 3, 1];

			for (int i = 0; i < ratings.Length; i++)
				yield return [ratings[i], expectedWeights[i], ratings];
		}
	}

	[Theory]
	[MemberData(nameof(NoData))]
	[MemberData(nameof(FictionalData))]
	[MemberData(nameof(RealWorldData))]
	public void TestLanguageWeight(double? tiobeRating, int expectedWeight, IEnumerable<double?> allRatings)
	{
		var actualWeight = LanguageEnumerablePickExtensions.GetWeightFromTiobeRating(tiobeRating, allRatings);

		Assert.Equal(expectedWeight, actualWeight);
	}
}
