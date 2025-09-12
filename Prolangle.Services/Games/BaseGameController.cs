using System.Collections.ObjectModel;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Services.Games;

public abstract class BaseGameController : IGameController
{
	public abstract IReadOnlyList<ILanguage> AvailableLanguages { get; }

	public IReadOnlyList<ILanguage> RevealedLanguages => CurrentlyRevealedLanguages;

	public abstract ILanguage? TargetLanguage { get; }

	protected Collection<ILanguage> CurrentlyRevealedLanguages { get; } = [];

	public bool Won => TargetLanguage is not null && RevealedLanguages.Contains(TargetLanguage);

	public abstract Task InitializeAsync(GameSeed? gameSeed = null);

	public virtual Task GuessAsync(ILanguage language)
	{
		CurrentlyRevealedLanguages.Add(language);

		return Task.CompletedTask;
	}
}
