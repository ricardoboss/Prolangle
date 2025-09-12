using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class FixedGameSeedProvider(uint seed, TimeSpan timeUntilNextSeed) : IGameSeedProvider
{
	public GameSeed GetCurrentGameSeed() => GameSeed.From(seed);

	public TimeSpan GetTimeUntilNextSeed() => timeUntilNextSeed;
}

public static class FixedGameSeedProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddFixedGameSeedProvider(this IServiceCollection services, uint seed,
		TimeSpan? timeUntilNextSeed = null)
	{
		var provider = new FixedGameSeedProvider(seed, timeUntilNextSeed ?? TimeSpan.FromMinutes(1));

		services.AddSingleton<IGameSeedProvider>(provider);

		return services;
	}
}
