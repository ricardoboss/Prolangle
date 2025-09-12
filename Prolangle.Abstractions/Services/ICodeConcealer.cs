using Blism;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

/// <summary>
/// Conceals parts of the code based on the given parameters.
/// </summary>
public interface ICodeConcealer
{
	/// <summary>
	/// Given a <paramref name="language"/> and a list of <paramref name="tokens"/>, conceals parts of the tokens based
	/// on <paramref name="revealedOffset"/> and <paramref name="revealedPercent"/>.
	/// </summary>
	/// <param name="language">The language the tokens stem from</param>
	/// <param name="tokens">The list of tokens to partially conceal</param>
	/// <param name="revealedOffset">The offset at which to start revealing tokens</param>
	/// <param name="revealedPercent">The extent of the revealed tokens (both in front of and behind <paramref name="revealedOffset"/>)</param>
	/// <returns>A list based on the given <paramref name="tokens"/> with some tokens concealed</returns>
	IReadOnlyList<SyntaxToken<GeneralTokenType>> ConcealTokens(ILanguage language,
		IReadOnlyList<SyntaxToken<GeneralTokenType>> tokens, double revealedOffset, double revealedPercent);
}
