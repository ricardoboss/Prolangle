using Blism;
using Blism.Language.Bash;
using Blism.Language.CSharp;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Languages;

namespace Prolangle.Services;

internal sealed class GeneralTokenizer(ILanguage language, ICodeTokenizer fallbackTokenizer) : ITokenizer<GeneralTokenType>
{
	private static readonly CSharpTokenizer CSharpTokenizer = new();
	private static readonly BashTokenizer BashTokenizer = new();

	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		return language switch
		{
			CSharp => CSharpTokenizer.Tokenize(code).Select(TranslateCSharpToken),
			Bash => BashTokenizer.Tokenize(code).Select(TranslateBashToken),
			_ => fallbackTokenizer.Tokenize(language, code),
		};
	}

	private static SyntaxToken<GeneralTokenType> TranslateBashToken(SyntaxToken<BashTokenType> bashToken) =>
		new()
		{
			Value = bashToken.Value,
			Type = bashToken.Type switch
			{
				BashTokenType.Unknown => GeneralTokenType.Unknown,
				BashTokenType.Punctuation => GeneralTokenType.Punctuation,
				BashTokenType.Whitespace => GeneralTokenType.Whitespace,
				BashTokenType.Comment => GeneralTokenType.Comment,
				BashTokenType.String => GeneralTokenType.Text,
				BashTokenType.Number => GeneralTokenType.Number,
				BashTokenType.Keyword => GeneralTokenType.Keyword,
				BashTokenType.SheBang => GeneralTokenType.Comment,
				BashTokenType.Identifier => GeneralTokenType.Identifier,
				BashTokenType.Command or BashTokenType.Option => GeneralTokenType.Identifier,
				_ => throw new NotImplementedException($"Unknown Bash token type: {bashToken.Type}"),
			},
		};

	private static SyntaxToken<GeneralTokenType> TranslateCSharpToken(SyntaxToken<CSharpTokenType> csharpToken) =>
		new()
		{
			Value = csharpToken.Value,
			Type = csharpToken.Type switch
			{
				CSharpTokenType.Unknown => GeneralTokenType.Unknown,
				CSharpTokenType.Keyword => GeneralTokenType.Keyword,
				CSharpTokenType.Punctuation => GeneralTokenType.Punctuation,
				CSharpTokenType.Number => GeneralTokenType.Number,
				CSharpTokenType.String => GeneralTokenType.Text,
				CSharpTokenType.Whitespace => GeneralTokenType.Whitespace,
				CSharpTokenType.Comment => GeneralTokenType.Comment,
				CSharpTokenType.Identifier => GeneralTokenType.Identifier,
				_ => throw new NotImplementedException($"Unknown C# token type: {csharpToken.Type}"),
			},
		};
}
