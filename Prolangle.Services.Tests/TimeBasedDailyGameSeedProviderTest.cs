namespace Prolangle.Services.Tests;

public static class TimeBasedDailyGameSeedProviderTest
{
	[Fact]
	public static void TestHappyPath()
	{
		var timeProviderMock = new Mock<TimeProvider>();

		timeProviderMock
			.Setup(t => t.GetUtcNow())
			.Returns(new DateTimeOffset(2025, 9, 3, 23, 55, 10, TimeSpan.Zero))
			.Verifiable();

		var provider = new TimeBasedDailyGameSeedProvider(timeProviderMock.Object);

		var gameSeed = provider.GetCurrentGameSeed(0);
		var timeUntilNext = provider.GetTimeUntilNextSeed();

		Assert.Equal(-748290048, gameSeed.Value);
		Assert.Equal(TimeSpan.FromSeconds(4 * 60 + 50), timeUntilNext);

		timeProviderMock.VerifyAll();
	}
}
