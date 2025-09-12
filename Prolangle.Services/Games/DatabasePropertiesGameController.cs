using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Services.Models;

namespace Prolangle.Services.Games;

public class DatabasePropertiesGameController(
	IGameSeedProvider gameSeedProvider,
	IDatabase database,
	ILanguagesProvider languagesProvider,
	ILanguageChooser languageChooser,
	TimeProvider timeProvider
) : DatabaseGameController(gameSeedProvider, database, languagesProvider, timeProvider, GameType.PropertiesGameTypeId),
	IPropertiesGameController
{
	private readonly ILanguagesProvider languagesProvider = languagesProvider;

	public override IReadOnlyList<ILanguage> AvailableLanguages { get; } = [.. languagesProvider.GetAll()];

	public override ILanguage? TargetLanguage => targetLanguage;

	private ILanguage? targetLanguage;

	protected override Task PrepareExistingGame(GameEntity gameEntity)
	{
		targetLanguage = languagesProvider.GetById(gameEntity.SolutionId);

		return Task.CompletedTask;
	}

	protected override SolutionId PrepareNewGame(GameSeed gameSeed)
	{
		targetLanguage = languageChooser.ChooseLanguage(gameSeed);

		return SolutionId.From(targetLanguage.Id);
	}
}

public static class DatabasePropertiesGameControllerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDatabasePropertiesGameController(this IServiceCollection services)
	{
		services.TryAddSingleton(TimeProvider.System);
		services.AddScoped<IPropertiesGameController, DatabasePropertiesGameController>();

		return services;
	}
}
