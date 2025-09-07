using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

/// <summary>
/// Tokenizes any given code by interpreting each individual character as a token.
/// </summary>
public class CharacterCodeTokenizer : ITokenizer<GeneralTokenType>
{
	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		return code.Select(c => new SyntaxToken<GeneralTokenType>
		{
			Value = c.ToString(),
			Type = GeneralTokenType.Unknown,
		});
	}
}

public static class CharacterCodeTokenizerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddCharacterCodeTokenizer(this IServiceCollection services)
	{
		services.AddSingleton<ITokenizer<GeneralTokenType>, CharacterCodeTokenizer>();

		return services;
	}
}
