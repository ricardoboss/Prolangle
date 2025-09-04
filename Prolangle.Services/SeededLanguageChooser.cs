using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class SeededLanguageChooser(IGameSeedProvider gameSeedProvider, ILanguagesProvider languagesProvider)
	: ILanguageChooser
{
	public ILanguage ChooseLanguage(GameSeed? seed = null)
	{
		var languages = languagesProvider.GetAll().ToList();
		if (languages.Count == 0)
			throw new InvalidOperationException("No languages are available");

		var languagesSeed = (seed ?? gameSeedProvider.GetCurrentGameSeed(1)).Value;
		languages.Shuffle(languagesSeed);

		return languages.First();
	}
}

public static class SeededLanguageChooserServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddSeededLanguageChooser(this IServiceCollection services)
	{
		services.AddSingleton<ILanguageChooser, SeededLanguageChooser>();

		return services;
	}
}
