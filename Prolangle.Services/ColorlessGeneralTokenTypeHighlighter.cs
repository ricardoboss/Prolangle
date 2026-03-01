using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services;

public class ColorlessGeneralTokenTypeHighlighter : BaseGeneralTokenTypeHighlighter, IColorlessTypeHighlighter
{
	public override string GetCss(GeneralTokenType tokenType) => GetDefaultCss();
}
