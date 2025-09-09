using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Services.Extensions;

namespace Prolangle.Services.Games;

public class DatabaseSnippetsGameManager(IDatabase database, IGameSeedProvider seedProvider, ISnippetChooser snippetChooser)
	: DatabaseGamesProvider<ISnippetsGame>(database), ISnippetsGameManager
{
	protected override async Task<ISnippetsGame> CreateInternalAsync(CancellationToken cancellationToken = default)
	{
		var languageSeed = seedProvider.GetCurrentSnippetsGameLanguageSeed();
		var snippetSeed = seedProvider.GetCurrentSnippetsGameSnippetSeed();

		var snippet = snippetChooser.ChooseSnippet(languageSeed, snippetSeed);

		throw new NotImplementedException();
	}

	protected override IAsyncEnumerable<ISnippetsGame> GetAllInternalAsync(
		CancellationToken cancellationToken = default)
	{
		return Database.GetAllAsync<ISnippetsGame>(cancellationToken);
	}

	protected override async Task<ISnippetsGame?> GetByGameSeedInternalAsync(GameSeed gameSeed,
		CancellationToken cancellationToken = default)
	{
		return await GetAllAsync(cancellationToken)
			.FirstOrDefaultAsync(g => g.GameSeed == gameSeed, cancellationToken: cancellationToken);
	}

	public async Task GuessAsync(ISnippetsGame game, ILanguage value, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}

public static class DatabaseSnippetsGameManagerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDatabaseSnippetsGameManager(this IServiceCollection services)
	{
		services.AddScoped<ISnippetsGameManager, DatabaseSnippetsGameManager>();

		return services;
	}
}
