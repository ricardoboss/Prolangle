namespace Prolangle.Services;

public class GameSeeder(Func<int> seeder, DateTime currentGametimestamp, DateTime nextGameTimestamp)
{
	public Func<int> Seeder { get; } = seeder;
	public DateTime NextGameTimestamp { get; } = nextGameTimestamp;
}
