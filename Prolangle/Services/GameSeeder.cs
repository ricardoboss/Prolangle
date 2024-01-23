namespace Prolangle.Services;

public class GameSeeder(Func<int> seeder, DateTime currentGameTimestamp, DateTime nextGameTimestamp)
{
	public Func<int> Seeder { get; } = seeder;
	public DateTime CurrentGameTimestamp { get; } = currentGameTimestamp;
	public DateTime NextGameTimestamp { get; } = nextGameTimestamp;
}
