using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class FixedGameSeedProvider(int seed, TimeSpan timeUntilNextSeed) : IGameSeedProvider
{
	public GameSeed GetCurrentGameSeed(int offset) => GameSeed.From(seed + offset);

	public TimeSpan GetTimeUntilNextSeed() => timeUntilNextSeed;
}
