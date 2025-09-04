using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

/// <summary>
/// Tokenizes any given code by interpreting each individual character as a token.
/// </summary>
public class CharacterCodeTokenizer : ICodeTokenizer
{
	public IReadOnlyList<CodeToken> Tokenize(ILanguage language, string code)
	{
		return [.. code.Select((c, i) => new CodeToken(i, c.ToString(), TokenType.Other))];
	}
}

public static class CharacterCodeTokenizerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddCharacterCodeTokenizer(this IServiceCollection services)
	{
		services.AddSingleton<ICodeTokenizer, CharacterCodeTokenizer>();

		return services;
	}
}
