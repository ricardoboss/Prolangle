using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public abstract class BaseGeneralTokenTypeHighlighter : ITokenTypeHighlighter<GeneralTokenType>
{
	public abstract string GetCss(GeneralTokenType tokenType);

	public string GetDefaultCss()
	{
		return "color: #d4d4d4; background-color: #1e1e1e;";
	}
}
