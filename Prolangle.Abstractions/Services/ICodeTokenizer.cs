using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

/// <summary>
/// Converts source code to a list of <see cref="CodeToken"/>s.
/// </summary>
public interface ICodeTokenizer
{
	/// <summary>
	/// Tokenizes the given <paramref name="code"/> based on the <paramref name="language"/>.
	/// </summary>
	/// <param name="language">The language the code is written in</param>
	/// <param name="code">The source code to tokenize</param>
	/// <returns>An enumerable set of <see cref="CodeToken"/>s</returns>
	IReadOnlyList<CodeToken> Tokenize(ILanguage language, string code);
}
