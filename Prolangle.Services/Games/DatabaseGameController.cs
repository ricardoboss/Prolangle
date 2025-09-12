using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Services.Models;

namespace Prolangle.Services.Games;

public abstract class DatabaseGameController(
	IGameSeedProvider gameSeedProvider,
	IDatabase database,
	ILanguagesProvider languagesProvider,
	TimeProvider timeProvider,
	GameType gameType
) : BaseGameController
{
	private GameEntity? game;

	public override async Task InitializeAsync(GameSeed? gameSeed = null)
	{
		if (game is not null)
			throw new InvalidOperationException("Game was already loaded/created!");

		if (!database.IsOpen)
			await database.OpenAsync();

		gameSeed ??= gameSeedProvider.GetCurrentGameSeed();

		game = await GetGameBySeedAsync(gameSeed.Value);

		if (game is null)
		{
			var solutionId = PrepareNewGame(gameSeed.Value);

			game = await CreateGameAsync(gameSeed.Value, solutionId);
		}
		else
		{
			await PrepareExistingGame(game);

			await LoadRevealedLanguages(game);
		}
	}

	protected abstract Task PrepareExistingGame(GameEntity gameEntity);

	private async Task<GameEntity?> CreateGameAsync(GameSeed gameSeed, SolutionId solutionId)
	{
		var entity = new GameEntity
		{
			Id = Guid.NewGuid(),
			PlayedAt = timeProvider.GetUtcNow(),
			Seed = gameSeed.Value,
			SolutionId = solutionId.Value,
			TypeId = gameType.Value,
		};

		await database.AddAsync(entity);

		return entity;
	}

	protected abstract SolutionId PrepareNewGame(GameSeed gameSeed);

	private async Task LoadRevealedLanguages(GameEntity gameEntity)
	{
		CurrentlyRevealedLanguages.Clear();

		await foreach (var language in GetRevealedLanguages(gameEntity))
			CurrentlyRevealedLanguages.Add(language);
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

	private async Task<GameEntity?> GetGameBySeedAsync(GameSeed seed)
	{
		return await database
			.GetAllAsync<GameEntity>()
			.Where(g => g.TypeId == gameType)
			.FirstOrDefaultAsync(g => g.Seed == seed.Value);
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
