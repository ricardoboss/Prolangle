using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class MarkdownTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly MarkdownTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		// whitespace + html comments
		yield return (new(@"\s+"), GeneralTokenType.Whitespace);
		yield return (new(@"<!--[\s\S]*?-->"), GeneralTokenType.Comment);

		// block markers (no ^ anchors; they’ll match when the cursor is at '#', '>', '-', etc.)
		yield return (new(@"#{1,6}\s.*"), GeneralTokenType.Keyword);          // headings
		yield return (new(@">\s.*"), GeneralTokenType.Keyword);               // blockquote
		yield return (new(@"(?:-{3,}|\*{3,}|_{3,})"), GeneralTokenType.Punctuation); // hr
		yield return (new(@"- \[(?: |x|X)\]\s+"), GeneralTokenType.Operator); // task list bullet
		yield return (new(@"(?:[-+*]|\d+\.)\s+"), GeneralTokenType.Operator); // list bullet/number

		// code
		yield return (new(@"(```|~~~)[^\n]*"), GeneralTokenType.Keyword);     // fence start/end lines
		yield return (new(@"`[^`]+`"), GeneralTokenType.Text);                // inline code

		// links & images (ESCAPES SUPPORTED)
		yield return (new(@"!\[(?:\\.|[^\]\\])*\]\((?:\\.|[^()\\])*\)"), GeneralTokenType.Identifier); // image
		yield return (new(@"\[(?:\\.|[^\]\\])*\]\((?:\\.|[^()\\])*\)"), GeneralTokenType.Identifier);  // inline link
		yield return (new(@"<https?:\/\/[^>\s]+>"), GeneralTokenType.Identifier);                      // autolink URL
		yield return (new(@"<[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}>"), GeneralTokenType.Identifier); // autolink email

		// emphasis / strike (kept simple so they don’t preempt links)
		yield return (new(@"~~.+?~~"), GeneralTokenType.Operator);
		yield return (new(@"(\*\*|__)(?:(?!\1).)+\1"), GeneralTokenType.Operator);
		yield return (new(@"(\*|_)(?:(?!\1).)+\1"), GeneralTokenType.Operator);

		// plain text — CRUCIAL: don’t consume inline openers so links can match at mid-line
		yield return (new(@"[^`\n!\[\]<*_~]+"), GeneralTokenType.Text);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
