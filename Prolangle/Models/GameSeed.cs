using Vogen;

namespace Prolangle.Models;

[ValueObject<int>]
[Instance("None", 0, "The uninitialized value.")]
public readonly partial struct GameSeed
{
	public static GameSeed FromTimestamp(DateTimeOffset timestamp) => (GameSeed)timestamp.GetHashCode();

	/// <summary>
	/// Creates a new <see cref="Random"/> with this seed.
	/// </summary>
	/// <param name="offset">The amount to offset the seed by.</param>
	/// <returns>A new <see cref="Random"/> with this seed.</returns>
	public Random GetRandom(int offset = 0)
	{
		var seed = (int)this;

		while (offset > 0)
		{
			seed++;
			seed %= int.MaxValue; // prevent overflow

			offset--;
		}

		return new Random(seed);
	}

	private static int NormalizeInput(int input) => input;

	private static Validation Validate(int input)
	{
		return input switch
		{
			0 => Validation.Invalid("Seed must not be 0"),
			int.MaxValue => Validation.Invalid("Seed must be less than Int32.MaxValue"),
			_ => Validation.Ok,
		};
	}
}
