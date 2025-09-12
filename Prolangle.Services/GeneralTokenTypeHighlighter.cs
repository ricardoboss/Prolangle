using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class GeneralTokenTypeHighlighter : ITokenTypeHighlighter<GeneralTokenType>
{
	public string GetCss(GeneralTokenType tokenType)
	{
		return tokenType switch
		{
			GeneralTokenType.Keyword => "color: #47a2ed; font-weight: bold;",
			GeneralTokenType.Number => "color: #b3cca4;",
			GeneralTokenType.Text => "color: #cc884e;",
			GeneralTokenType.Comment => "color: #699856; font-style: italic;",
			GeneralTokenType.Identifier => "color: #94dbfd;",
			_ => "",
		};
	}

	public string GetDefaultCss()
	{
		return "color: #d4d4d4; background-color: #1e1e1e;";
	}
}

public static class GeneralTokenTypeHighlighterServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddGeneralTokenTypeHighlighter(this IServiceCollection services)
	{
		services.AddSingleton<ITokenTypeHighlighter<GeneralTokenType>, GeneralTokenTypeHighlighter>();

		return services;
	}
}
