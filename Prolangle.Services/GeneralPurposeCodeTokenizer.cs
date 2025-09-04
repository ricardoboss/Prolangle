using Blism;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

/// <summary>
/// Tokenizes any given code by interpreting each individual word as a token (separated by certain characters).
/// </summary>
public class GeneralPurposeCodeTokenizer : ICodeTokenizer
{
	private static readonly HashSet<char> OperatorChars =
		['+', '-', '*', '/', '%', '=', '!', '<', '>', '&', '|', '^', '~', '?'];

	private static readonly HashSet<char> PunctuationChars =
		['(', ')', '{', '}', '[', ']', ';', ',', '.', ':'];

	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(ILanguage language, string code)
	{
		List<SyntaxToken<GeneralTokenType>> tokens = [];
		int i = 0;

		while (i < code.Length)
		{
			char c = code[i];

			// --- whitespace ---
			if (char.IsWhiteSpace(c))
			{
				int start = i;
				while (i < code.Length && char.IsWhiteSpace(code[i])) i++;
				Emit(GeneralTokenType.Whitespace, start, i);
			}
			// --- comments ---
			else if (c == '/' && i + 1 < code.Length)
			{
				switch (code[i + 1])
				{
					// C++, C#, Java, etc
					case '/':
						{
							int start = i;
							i += 2;
							while (i < code.Length && code[i] != '\n') i++;
							Emit(GeneralTokenType.Comment, start, i);
							break;
						}
					// C-style block comment
					case '*':
						{
							int start = i;
							i += 2;
							while (i + 1 < code.Length && !(code[i] == '*' && code[i + 1] == '/')) i++;
							i = Math.Min(i + 2, code.Length);
							Emit(GeneralTokenType.Comment, start, i);
							break;
						}
					default:
						i = HandleOperatorOrPunct(c);
						break;
				}
			}
			else if (c is '#' or ';' && i + 1 < code.Length && code[i + 1] is not '\n' and not '\r') // shell, python, SQL, PowerShell
			{
				int start = i;
				while (i < code.Length && code[i] != '\n') i++;
				Emit(GeneralTokenType.Comment, start, i);
			}
			else if (c == '-' && i + 1 < code.Length && code[i + 1] == '-') // SQL
			{
				int start = i;
				i += 2;
				while (i < code.Length && code[i] != '\n') i++;
				Emit(GeneralTokenType.Comment, start, i);
			}
			else if (c == '<' && i + 3 < code.Length && code[i..].StartsWith("<!--", StringComparison.OrdinalIgnoreCase)) // HTML/XML
			{
				int start = i;
				i += 4;
				while (i + 2 < code.Length && !(code[i] == '-' && code[i + 1] == '-' && code[i + 2] == '>')) i++;
				i = Math.Min(i + 3, code.Length);
				Emit(GeneralTokenType.Comment, start, i);
			}
			// --- identifiers ---
			else if (char.IsLetter(c) || c == '_')
			{
				int start = i;
				while (i < code.Length && (char.IsLetterOrDigit(code[i]) || code[i] == '_')) i++;
				Emit(GeneralTokenType.Identifier, start, i);
			}
			// --- numbers ---
			else if (char.IsDigit(c))
			{
				int start = i;
				while (i < code.Length && char.IsDigit(code[i])) i++;

				if (i < code.Length && code[i] == '.')
				{
					i++;
					while (i < code.Length && char.IsDigit(code[i])) i++;
				}

				Emit(GeneralTokenType.Number, start, i);
			}
			// --- strings ---
			else if (c is '"' or '\'' or '`')
			{
				int start = i++;
				while (i < code.Length)
				{
					if (code[i] == '\\')
					{
						i += 2;
						continue;
					}

					if (code[i] == c)
					{
						i++;
						break;
					}

					i++;
				}

				Emit(GeneralTokenType.Text, start, i);
			}
			// --- operators & punctuation ---
			else
			{
				i = HandleOperatorOrPunct(c);
			}
		}

		return tokens;

		void Emit(GeneralTokenType type, int start, int end)
		{
			tokens.Add(new()
			{
				Value = code[start..end],
				Type = type,
			});
		}

		int HandleOperatorOrPunct(char c)
		{
			if (OperatorChars.Contains(c))
			{
				int start = i++;
				while (i < code.Length && OperatorChars.Contains(code[i])) i++;
				Emit(GeneralTokenType.Operator, start, i);
			}
			else if (PunctuationChars.Contains(c))
			{
				Emit(GeneralTokenType.Punctuation, i, ++i);
			}
			else
			{
				Emit(GeneralTokenType.Unknown, i, ++i);
			}

			return i;
		}
	}
}

public static class GeneralPurposeCodeTokenizerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddGeneralPurposeCodeTokenizer(this IServiceCollection services)
	{
		services.AddSingleton<ICodeTokenizer, GeneralPurposeCodeTokenizer>();

		return services;
	}
}
