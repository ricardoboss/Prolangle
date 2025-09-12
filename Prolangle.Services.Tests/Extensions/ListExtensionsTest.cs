using System.Diagnostics;
using Prolangle.Services.Extensions;

namespace Prolangle.Services.Tests.Extensions;

public static class ListExtensionsTest
{
	[Fact]
	public static void TestThrowsForReadOnlyLists()
	{
		var list = new List<int> { 1, 2, 3 }.AsReadOnly();

		Assert.Throws<ArgumentException>(() => list.Shuffle());
	}

	[Fact]
	public static void TestDoesntThrowForArrays()
	{
		int[] list = [1, 2, 3];

		list.Shuffle(); // shouldn't throw
	}

	[Theory]
	[MemberData(nameof(ShuffleTestCaseData))]
	public static void TestShuffle(int? seed, IList<int> list, IList<int>? expectedOrder)
	{
		int[] original = [.. list];

		list.Shuffle(seed); // shuffles in-place

		Assert.Equal(original.Length, list.Count); // length shouldn't change

		bool anyElementDifferent = false;
		foreach (var (o, i) in original.Order().Zip(list.Order()))
		{
			if (o == i)
				continue;

			anyElementDifferent = true;
			break;
		}

		if (anyElementDifferent)
			Assert.Fail("List no longer contains one or more of the original elements");

		if (seed is null)
		{
			bool anyIndexDifferent = false;
			foreach (var (o, i) in original.Zip(list))
			{
				if (o == i)
					continue;

				anyIndexDifferent = true;
				break;
			}

			if (!anyIndexDifferent)
				Assert.Fail("List order hasn't changed after shuffling");
		}
		else
		{
			Debug.Assert(expectedOrder is not null, "Seeded runs should include an expected order");

			bool anyExpectedDifferent = false;
			foreach (var (e, i) in expectedOrder.Zip(list))
			{
				if (e == i)
					continue;

				anyExpectedDifferent = true;
				break;
			}

			if (anyExpectedDifferent)
				Assert.Fail($"List order doesn't matched expected order (seed: {seed}, got: {string.Join(',', list)})");
		}
	}

	public static IEnumerable<TheoryDataRow<int?, int[], int[]?>> ShuffleTestCaseData()
	{
		yield return new(null, [.. Enumerable.Range(0, 100)], null);
		yield return new(2, [1, 2, 3], [2, 1, 3]);
		yield return new(1, [1, 2, 3, 4, 5], [4, 3, 5, 1, 2]);
		yield return new(1, [1, 2, 3, 4, 5, 6], [5, 4, 3, 6, 1, 2]);
		yield return new(1, [1, 2, 3, 4, 5, 6, 7], [5, 6, 7, 4, 3, 1, 2]);
	}
}
