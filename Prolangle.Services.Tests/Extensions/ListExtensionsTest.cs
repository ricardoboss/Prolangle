using Prolangle.Services.Extensions;

namespace Prolangle.Services.Tests.Extensions;

public static class ListExtensionsTest
{
	[Theory]
	[MemberData(nameof(PickRandomTestCaseData))]
	public static void TestPickRandomSeeded(uint seed, IReadOnlyList<int> list, int expected)
	{
		var result = list.PickRandom(seed);

		Assert.Equal(expected, result);
	}

	public static IEnumerable<TheoryDataRow<uint, int[], int>> PickRandomTestCaseData()
	{
		int[] source = [.. Enumerable.Range(0, 100)];

		yield return new(0, source, 0);
		yield return new(1, source, 52);
		yield return new(2, source, 5);
		yield return new(3, source, 73);
		yield return new(uint.MaxValue, source, 46);
	}
}
