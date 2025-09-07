using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class BrainfuckTokenizer : BaseTokenizer<GeneralTokenType>
{
	public static readonly BrainfuckTokenizer Instance = new();

	protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
	{
		yield return (new(@"[+\-<>[\].,]"), GeneralTokenType.Operator);
		yield return (new(@"[^+\-<>[\].,]+"), GeneralTokenType.Comment);
	}

	protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
