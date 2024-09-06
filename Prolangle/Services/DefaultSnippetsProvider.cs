using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Snippets;

namespace Prolangle.Services;

public class DefaultSnippetsProvider : ISnippetsProvider
{
	public DefaultSnippetsProvider()
	{
		Snippets = GetType().Assembly.GetTypes()
			.Where(t => typeof(ICodeSnippet).IsAssignableFrom(t) && t.IsClass)
			.Select(t => (ICodeSnippet)Activator.CreateInstance(t)!)
			.ToLookup(cs => cs.Language);
	}

	private ILookup<ILanguage, ICodeSnippet> Snippets { get; }

	public IEnumerable<ICodeSnippet> GetSnippets(ILanguage language) => Snippets[language];
}
