using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class TimeBasedDailyGameSeedProvider(TimeProvider timeProvider)
	: IGameSeedProvider
{
	public GameSeed GetCurrentGameSeed()
	{
		var today = GetToday();

		return GameSeed.From((int)today.Ticks % int.MaxValue);
	}

	private DateTimeOffset GetToday()
	{
		var (dateOnly, _, _) = timeProvider.GetUtcNow();
		var today = new DateTimeOffset(dateOnly, TimeOnly.MinValue, TimeSpan.Zero);
		return today;
	}

	public TimeSpan GetTimeUntilNextSeed()
	{
		var now = timeProvider.GetUtcNow();
		var nextGame = GetToday().AddDays(1);

		return nextGame - now;
	}
}

public static class TimeBasedDailyGameSeedProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddTimeBasedDailyGameSeedProvider(this IServiceCollection services)
	{
		services.TryAddSingleton(TimeProvider.System);
		services.AddSingleton<IGameSeedProvider, TimeBasedDailyGameSeedProvider>();

		return services;
	}
}
