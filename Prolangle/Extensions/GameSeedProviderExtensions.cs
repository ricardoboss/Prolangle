using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Services;

namespace Prolangle.Extensions;

internal static class GameSeedProviderExtensions
{
	public static GameSeed GetCurrentPropertiesGameSeed(this IGameSeedProvider provider) =>
		provider.GetCurrentGameSeed(1);

	public static GameSeed GetCurrentSnippetsGameLanguageSeed(this IGameSeedProvider provider) =>
		provider.GetCurrentGameSeed(2);

	public static GameSeed GetCurrentSnippetsGameSnippetSeed(this IGameSeedProvider provider) =>
		provider.GetCurrentGameSeed(3);

	public static GameSeed GetCurrentSnippetsGameJitterSeed(this IGameSeedProvider provider) =>
		provider.GetCurrentGameSeed(4);
}
