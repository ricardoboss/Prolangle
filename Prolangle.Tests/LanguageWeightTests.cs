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
	[InlineData(0.5, 200)]
	[InlineData(1.0, 100)]
	[InlineData(20.0, 99)]

	// real-world examples
	[InlineData(0.47, 212)] // Dart
	[InlineData(0.79, 126)] // Rust
	[InlineData(1.11, 99)] // Assembly
	[InlineData(2.9, 99)] // JS
	[InlineData(11.44, 99)] // C
	public void TestLanguageWeight(double? tiobeRating, int expectedWeight)
	{
		var actualWeight = LanguageEnumerablePickExtensions.GetWeightFromTiobeRating(tiobeRating);

		Assert.Equal(expectedWeight, actualWeight);
	}
}
