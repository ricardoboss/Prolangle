using System.Diagnostics.CodeAnalysis;
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
) : AdHocSnippetsGameController(snippetsProvider, snippetChooser)
{
	private readonly ISnippetsProvider snippetsProvider = snippetsProvider;

	private readonly ISnippetChooser snippetChooser = snippetChooser;

	private GameEntity? game;

	protected override async Task<ICodeSnippet> ChooseSnippet(GameSeed? gameSeed)
	{
		if (game is not null)
			throw new InvalidOperationException("Game was already loaded/created!");

		gameSeed ??= gameSeedProvider.GetCurrentGameSeed();

		if (!database.IsOpen)
			await database.OpenAsync();

		game = await GetGameBySeedAsync(gameSeed);

		ICodeSnippet snippet;
		if (game is null)
		{
			snippet = snippetChooser.ChooseSnippet(gameSeed);

			game = await CreateGameAsync(gameSeed, snippet);
		}
		else
		{
			snippet = snippetsProvider.GetById(game.SolutionId);

			await foreach (var language in GetRevealedLanguages(game))
				AdHocRevealedLanguages.Add(language);
		}

		return snippet;
	}

	private IAsyncEnumerable<ILanguage> GetRevealedLanguages(GameEntity gameEntity)
	{
		return database
			.GetAllAsync<GuessEntity>()
			.Where(g => g.GameId == gameEntity.Id)
			.OrderBy(g => g.PlayedAt)
			.Select(g => g.LanguageId)
			.Select(languagesProvider.GetById);
	}

	private async Task<GameEntity> CreateGameAsync([DisallowNull] GameSeed? gameSeed, ICodeSnippet snippet)
	{
		var entity = new GameEntity
		{
			Id = Guid.NewGuid(),
			PlayedAt = timeProvider.GetUtcNow(),
			Seed = gameSeed.Value.Value,
			SolutionId = snippet.Id,
			TypeId = GameType.SnippetsGameTypeId,
		};

		await database.AddAsync(entity);

		return entity;
	}

	private async Task<GameEntity?> GetGameBySeedAsync([DisallowNull] GameSeed? gameSeed)
	{
		return await database
			.GetAllAsync<GameEntity>()
			.Where(g => g.TypeId == GameType.SnippetsGameTypeId)
			.FirstOrDefaultAsync(g => g.Seed == gameSeed.Value);
	}

	public override async Task GuessAsync(ILanguage language)
	{
		if (game is null)
			throw new InvalidOperationException("No game was loaded/created!");

		await base.GuessAsync(language);

		await CreateGuessAsync(game, language);
	}

	private async Task CreateGuessAsync(GameEntity gameEntity, ILanguage language)
	{
		var entity = new GuessEntity
		{
			GameId = gameEntity.Id,
			PlayedAt = timeProvider.GetUtcNow(),
			LanguageId = language.Id,
		};

		await database.AddAsync(entity);
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
