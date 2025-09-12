using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Services;

public interface ISnippetsProvider
{
	IEnumerable<ICodeSnippet> GetAll();

	IEnumerable<ILanguage> GetAvailableLanguages() => GetAll().Select(s => s.Language).Distinct();

	IEnumerable<ICodeSnippet> GetAllForLanguage(ILanguage language) =>
		GetAll().Where(s => s.Language == language);

	ICodeSnippet GetById(Guid id) =>
		GetAll().FirstOrDefault(s => s.Id == id) ?? throw SnippetNotFoundException.ById(id);
}
