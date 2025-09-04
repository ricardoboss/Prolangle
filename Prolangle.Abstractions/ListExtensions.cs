using System.Diagnostics.CodeAnalysis;

namespace Prolangle.Abstractions;

public static class ListExtensions
{
	[SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
	public static void Shuffle<T>(this IList<T> source, int? seed = null)
	{
		var prng = seed.HasValue ? new Random(seed.Value) : new();

		for (int i = source.Count; i > 1; i--)
		{
			int j = prng.Next(i);

			(source[i - 1], source[j]) = (source[j], source[i - 1]);
		}
	}
}
