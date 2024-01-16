using Prolangle.Languages.Framework;

namespace Prolangle.Snippets;

public interface ICodeSnippet
{
	ILanguage Language { get; }

	string Filename { get; }

	string SourceCode { get; }
}
