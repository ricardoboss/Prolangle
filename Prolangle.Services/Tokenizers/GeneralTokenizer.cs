using Blism;
using Blism.Language.Bash;
using Blism.Language.CSharp;
using Blism.Language.Dart;
using Blism.Language.Php;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Languages;

namespace Prolangle.Services.Tokenizers;

public class GeneralTokenizer(ILanguage language, ICodeTokenizer fallbackTokenizer) : ITokenizer<GeneralTokenType>
{
	public IEnumerable<SyntaxToken<GeneralTokenType>> Tokenize(string code)
	{
		return language switch
		{
			CSharp => CSharpTokenizer.Instance.Tokenize(code).Select(TranslateCSharpToken),
			Bash => BashTokenizer.Instance.Tokenize(code).Select(TranslateBashToken),
			Php => PhpTokenizer.Instance.Tokenize(code).Select(TranslatePhpToken),
			Dart => DartTokenizer.Instance.Tokenize(code).Select(TranslateDartToken),
			// TODO: add YAML tokenizer from Blism when YAML gets added to Prolangle
			Xml or Html => XmlLikeTokenizer.Instance.Tokenize(code),
			Css => CssTokenizer.Instance.Tokenize(code),
			_ => fallbackTokenizer.Tokenize(language, code),
		};
	}

	private static SyntaxToken<GeneralTokenType> TranslateDartToken(SyntaxToken<DartTokenType> dartToken)
	{
		return new()
		{
			Value = dartToken.Value,
			Type = dartToken.Type switch
			{
				DartTokenType.Unknown => GeneralTokenType.Unknown,
				DartTokenType.Comment => GeneralTokenType.Comment,
				DartTokenType.String => GeneralTokenType.Text,
				DartTokenType.Number => GeneralTokenType.Number,
				DartTokenType.Punctuation => GeneralTokenType.Punctuation,
				DartTokenType.Whitespace => GeneralTokenType.Whitespace,
				DartTokenType.Keyword => GeneralTokenType.Keyword,
				DartTokenType.Identifier => GeneralTokenType.Identifier,
				_ => throw new NotImplementedException($"Unknown Dart token type: {dartToken.Type}"),
			},
		};
	}

	private static SyntaxToken<GeneralTokenType> TranslatePhpToken(SyntaxToken<PhpTokenType> phpToken) =>
		new()
		{
			Value = phpToken.Value,
			Type = phpToken.Type switch
			{
				PhpTokenType.Unknown => GeneralTokenType.Unknown,
				PhpTokenType.Whitespace => GeneralTokenType.Whitespace,
				PhpTokenType.Keyword => GeneralTokenType.Keyword,
				PhpTokenType.String => GeneralTokenType.Text,
				PhpTokenType.Number => GeneralTokenType.Number,
				PhpTokenType.Comment => GeneralTokenType.Comment,
				PhpTokenType.Identifier or PhpTokenType.Variable => GeneralTokenType.Identifier,
				_ => throw new NotImplementedException($"Unknown PHP token type: {phpToken.Type}"),
			},
		};

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
