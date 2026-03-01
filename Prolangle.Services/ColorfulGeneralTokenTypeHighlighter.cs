using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Services;

public class ColorfulGeneralTokenTypeHighlighter : BaseGeneralTokenTypeHighlighter, IColorfulTypeHighlighter
{
	public override string GetCss(GeneralTokenType tokenType)
	{
		return tokenType switch
		{
			GeneralTokenType.Keyword => "color: #47a2ed; font-weight: bold;",
			GeneralTokenType.Number => "color: #b3cca4;",
			GeneralTokenType.Text => "color: #cc884e;",
			GeneralTokenType.Comment => "color: #699856; font-style: italic;",
			GeneralTokenType.Identifier => "color: #94dbfd;",
			_ => "",
		};
	}
}
