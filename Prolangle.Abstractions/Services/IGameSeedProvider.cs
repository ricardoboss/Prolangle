using Prolangle.Abstractions.Games;

namespace Prolangle.Abstractions.Services;

public interface IGameSeedProvider
{
	GameSeed GetCurrentGameSeed(int offset = 0);

	TimeSpan GetTimeUntilNextSeed();
}
