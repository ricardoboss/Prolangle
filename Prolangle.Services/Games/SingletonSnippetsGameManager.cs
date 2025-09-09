using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Services.Extensions;
using Prolangle.Services.Models;

namespace Prolangle.Services.Games;

public class SingletonSnippetsGameManager(
	IGameSeedProvider seedProvider,
	ISnippetChooser snippetChooser,
	ISnippetsProvider snippetsProvider)
	: ISnippetsGameManager
{
	private StatefulSnippetsGame? Game { get; set; }

	public Task GuessAsync(ISnippetsGame game, ILanguage value, CancellationToken cancellationToken = default)
	{
		if (game != Game)
			throw new ArgumentException(
				$"{nameof(SingletonSnippetsGameManager)} can only track a single game instance");

		Game.ModifiableGuesses.Add(new DefaultSnippetsGameGuess
		{
			Guess = value,
			GuessedAt = DateTimeOffset.UtcNow,
		});

		return Task.CompletedTask;
	}

	public Task<ISnippetsGame> CreateAsync(CancellationToken cancellationToken = default)
	{
		var languageSeed = seedProvider.GetCurrentSnippetsGameLanguageSeed();
		var snippetSeed = seedProvider.GetCurrentSnippetsGameSnippetSeed();

		var snippet = snippetChooser.ChooseSnippet(languageSeed, snippetSeed);

		Game = new(snippetsProvider)
		{
			Id = Guid.NewGuid(),
			PlayedAt = DateTimeOffset.UtcNow,
			GameSeed = languageSeed,
			Target = snippet,
		};

		return Task.FromResult<ISnippetsGame>(Game);
	}

	public async IAsyncEnumerable<ISnippetsGame> GetAllAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		if (Game is null)
			yield break;

		yield return Game;
	}

	public Task<ISnippetsGame?> GetByGameSeedAsync(GameSeed gameSeed,
		CancellationToken cancellationToken = default)
	{
		if (Game is { GameSeed: var s } g && s == gameSeed)
			return Task.FromResult<ISnippetsGame?>(g);

		return Task.FromResult<ISnippetsGame?>(null);
	}
}

public static class SingletonSnippetsGameManagerServiceCollectionExtension
{
	[PublicAPI]
	public static IServiceCollection AddSingletonSnippetsGameManager(this IServiceCollection services)
	{
		services.AddSingleton<ISnippetsGameManager, SingletonSnippetsGameManager>();

		return services;
	}
}
