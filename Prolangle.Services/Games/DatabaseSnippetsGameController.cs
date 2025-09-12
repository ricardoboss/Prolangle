using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;
using Prolangle.Services.Models;

namespace Prolangle.Services.Games;

public class DatabaseSnippetsGameController(
	IGameSeedProvider gameSeedProvider,
	ISnippetsProvider snippetsProvider,
	ISnippetChooser snippetChooser,
	IDatabase database,
	TimeProvider timeProvider,
	ILanguagesProvider languagesProvider
) : DatabaseGameController(gameSeedProvider, database, languagesProvider, timeProvider, GameType.SnippetsGameTypeId),
	ISnippetsGameController
{
	public override IReadOnlyList<ILanguage> AvailableLanguages { get; } =
		[.. snippetsProvider.GetAvailableLanguages()];

	public bool RevealFilename => RevealedLanguages.Count >= 10;

	public override ILanguage? TargetLanguage => Snippet?.Language;

	public ICodeSnippet? Snippet { get; private set; }

	public double RevealedPercent => Won ? 1 : RevealedLanguages.Count * RevealedPerGuess;

	private double RevealedPerGuess => 2d / AvailableLanguages.Count;

	protected override Task PrepareExistingGame(GameEntity gameEntity)
	{
		Snippet = snippetsProvider.GetById(gameEntity.SolutionId);

		return Task.CompletedTask;
	}

	protected override SolutionId PrepareNewGame(GameSeed gameSeed)
	{
		Snippet = snippetChooser.ChooseSnippet(gameSeed);

		return SolutionId.From(Snippet.Id);
	}
}

public static class DatabaseSnippetsGameControllerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDatabaseSnippetsGameController(this IServiceCollection services)
	{
		services.AddScoped<ISnippetsGameController, DatabaseSnippetsGameController>();

		return services;
	}
}
