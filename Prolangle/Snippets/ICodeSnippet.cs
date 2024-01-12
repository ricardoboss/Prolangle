using Prolangle.Languages.Framework;

namespace Prolangle.Snippets;

public interface ICodeSnippet
{
	ILanguage Language { get; }

	string SourceCode { get; }
}
