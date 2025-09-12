using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services.Games;

public class AdHocSnippetsGameController(ISnippetsProvider snippetsProvider, ISnippetChooser snippetChooser) : ISnippetsGameController
{
	public IReadOnlyList<ILanguage> AvailableLanguages { get; } = [.. snippetsProvider.GetAvailableLanguages()];

	public ObservableCollection<ILanguage> RevealedLanguages => AdHocRevealedLanguages;

	protected ObservableCollection<ILanguage> AdHocRevealedLanguages { get; } = [];

	public bool Won => TargetLanguage is not null && RevealedLanguages.Contains(TargetLanguage);

	public bool RevealFilename => RevealedLanguages.Count >= 10;

	public ILanguage? TargetLanguage => Snippet?.Language;

	public ICodeSnippet? Snippet { get; private set; }

	public double RevealedPercent => Won ? 1 : RevealedLanguages.Count * RevealedPerGuess;

	private double RevealedPerGuess => 2d / AvailableLanguages.Count;

	public virtual async Task InitializeAsync(GameSeed? gameSeed = null)
	{
		Snippet = await ChooseSnippet(gameSeed);
	}

	protected virtual Task<ICodeSnippet> ChooseSnippet(GameSeed? gameSeed)
	{
		var snippet = snippetChooser.ChooseSnippet(gameSeed);

		return Task.FromResult(snippet);
	}

	public virtual Task GuessAsync(ILanguage language)
	{
		AdHocRevealedLanguages.Add(language);

		return Task.CompletedTask;
	}
}

public static class AdHocSnippetsGameControllerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddAdHocSnippetsGameController(this IServiceCollection services)
	{
		services.AddTransient<ISnippetsGameController, AdHocSnippetsGameController>();

		return services;
	}
}
