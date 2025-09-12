using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class TimeBasedHourlyGameSeedProvider(TimeProvider timeProvider)
	: IGameSeedProvider
{
	public GameSeed GetCurrentGameSeed()
	{
		var today = GetThisHour();

		return GameSeed.From((int)today.Ticks % int.MaxValue);
	}

	private DateTimeOffset GetThisHour()
	{
		var (dateOnly, timeOnly, _) = timeProvider.GetUtcNow();
		var thisHour = new DateTimeOffset(dateOnly, TimeOnly.FromTimeSpan(TimeSpan.FromHours(timeOnly.Hour)),
			TimeSpan.Zero);
		return thisHour;
	}

	public TimeSpan GetTimeUntilNextSeed()
	{
		var now = timeProvider.GetUtcNow();
		var nextGame = GetThisHour().AddHours(1);

		return nextGame - now;
	}
}

public static class TimeBasedHourlyGameSeedProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddTimeBasedHourlyGameSeedProvider(this IServiceCollection services)
	{
		services.TryAddSingleton(TimeProvider.System);
		services.AddSingleton<IGameSeedProvider, TimeBasedHourlyGameSeedProvider>();

		return services;
	}
}
