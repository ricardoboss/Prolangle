using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

/// <summary>
/// Tokenizes any given code by interpreting each individual word as a token (separated by whitespace).
/// </summary>
public class WordsCodeTokenizer : ICodeTokenizer
{
	public IReadOnlyList<CodeToken> Tokenize(ILanguage language, string code)
	{
		return [..splitIntoWords()];

		IEnumerable<CodeToken> splitIntoWords()
		{
			StringBuilder wordBuilder = new();
			var index = 0;
			foreach (var c in code)
			{
				if (char.IsWhiteSpace(c))
				{
					if (wordBuilder.Length > 0)
					{
						var word = wordBuilder.ToString();
						wordBuilder.Clear();

						yield return new(index - word.Length, word, TokenType.Other);
					}

					yield return new(index, c.ToString(), TokenType.Whitespace);
				}
				else
				{
					wordBuilder.Append(c);
				}

				index++;
			}

			// handle leftover chars
			if (wordBuilder.Length > 0)
			{
				var word = wordBuilder.ToString();

				yield return new(index - word.Length, word, TokenType.Other);
			}
		}
	}
}

public static class WordsCodeTokenizerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddWordsCodeTokenizer(this IServiceCollection services)
	{
		services.AddSingleton<ICodeTokenizer, WordsCodeTokenizer>();

		return services;
	}
}
