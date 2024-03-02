using Prolangle.Extensions;
using Prolangle.Languages.Framework;
using Prolangle.Services;
using Weighted_Randomizer;

namespace Prolangle.Tests;

public class LanguageWeightTests
{
	[Theory]

	// language has no data
	[InlineData(null, 100)]
	[InlineData(0.0, 100)]

	// fictional languages
	[InlineData(0.5, 99)]
	[InlineData(1.0, 99)]
	[InlineData(20.0, 5)]

	// real-world examples
	[InlineData(0.47, 99)] // Dart
	[InlineData(0.79, 99)] // Rust
	[InlineData(1.11, 90)] // Assembly
	[InlineData(2.9, 34)] // JS
	[InlineData(11.44, 8)] // C
	public void TestLanguageWeight(double? tiobeRating, int expectedWeight)
	{
		var actualWeight = LanguageEnumerablePickExtensions.GetWeightFromTiobeRating(tiobeRating);

		Assert.Equal(expectedWeight, actualWeight);
	}
}
