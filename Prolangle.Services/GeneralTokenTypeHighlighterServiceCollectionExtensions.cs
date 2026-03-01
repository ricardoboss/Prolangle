using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services;

public static class GeneralTokenTypeHighlighterServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddGeneralTokenTypeHighlighters(this IServiceCollection services)
	{
		services.AddSingleton<IColorfulTypeHighlighter, ColorfulGeneralTokenTypeHighlighter>();
		services.AddSingleton<IColorlessTypeHighlighter, ColorlessGeneralTokenTypeHighlighter>();

		return services;
	}
}
