using Prolangle.Languages.Framework;
using Prolangle.Snippets;

namespace Prolangle.Services;

public class LanguageSnippetProvider
{
	private readonly Func<int> _seedGenerator;

	public LanguageSnippetProvider(GameSeeder seedGenerator)
	{
		_seedGenerator = seedGenerator.Seeder;

		Snippets = this.GetType().Assembly.GetTypes()
			.Where(t => typeof(ICodeSnippet).IsAssignableFrom(t) && t.IsClass)
			.Select(t => (ICodeSnippet)Activator.CreateInstance(t)!)
			.ToLookup(cs => cs.Language);

		SupportedLanguages = Snippets
			.Select(g => g.Key)
			.OrderBy(l => l.Name)
			.ToList();
	}

	private ILookup<ILanguage, ICodeSnippet> Snippets { get; }
	public IReadOnlyList<ILanguage> SupportedLanguages { get; }

	public ICodeSnippet GetSnippet(ILanguage language)
	{
		var random = new Random(_seedGenerator());

		ICodeSnippet[] currentLanguageSnippets = Snippets[language].ToArray();

		if (currentLanguageSnippets.Length == 0)
			throw new NotSupportedException("Language not supported");

		random.Shuffle(currentLanguageSnippets);

		return currentLanguageSnippets.First();
	}
}
