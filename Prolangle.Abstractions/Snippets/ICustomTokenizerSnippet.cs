using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Abstractions.Snippets;

public interface ICustomTokenizerSnippet
{
	/// <summary>
	/// If non-default, which tokenizer to use instead of the one for the language. This useful for different dialects
	/// of the same langauge (like Assembly or SQL).
	/// </summary>
	ITokenizer<GeneralTokenType> Tokenizer { get; }
}
