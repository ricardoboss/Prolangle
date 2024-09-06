using Prolangle.Languages.Framework;
using Prolangle.Snippets;

namespace Prolangle.Interfaces;

public interface ISnippetsProvider
{
	IEnumerable<ICodeSnippet> GetSnippets(ILanguage language);
}
