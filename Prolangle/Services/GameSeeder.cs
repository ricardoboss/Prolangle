namespace Prolangle.Services;

public class GameSeeder(Func<int> seeder)
{
	public Func<int> Seeder { get; } = seeder;
}
