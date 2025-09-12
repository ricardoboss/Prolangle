using System.Diagnostics.CodeAnalysis;

namespace Prolangle.Services.Extensions;

public static class ListExtensions
{
	[SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
	public static T PickRandom<T>(this IReadOnlyList<T> source, uint? seed = null)
	{
		if (source.Count == 0)
			throw new ArgumentException("Sequence is empty", nameof(source));

		if (seed is { } h)
		{
			// Murmur3’s finalizer constants (avalanche for nearby seeds)
			h ^= h >> 16;
			h *= 0x7feb352d;
			h ^= h >> 15;
			h *= 0x846ca68b;
			h ^= h >> 16;

			return source[(int)(h % (uint)source.Count)];
		}

		var idx = Random.Shared.Next(source.Count);

		return source[idx];
	}
}
