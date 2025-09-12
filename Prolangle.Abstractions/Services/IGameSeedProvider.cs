using Prolangle.Abstractions.Games;

namespace Prolangle.Abstractions.Services;

public interface IGameSeedProvider
{
	GameSeed GetCurrentGameSeed();

	TimeSpan GetTimeUntilNextSeed();
}
