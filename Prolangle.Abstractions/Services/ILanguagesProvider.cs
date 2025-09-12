using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

/// <summary>
/// Provides access to all available programming languages.
/// </summary>
public interface ILanguagesProvider
{
	/// <summary>
	/// Returns all available programming languages.
	/// </summary>
	/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ILanguage"/> instances.</returns>
	IEnumerable<ILanguage> GetAll();

	/// <summary>
	/// Tries to find a <see cref="ILanguage"/> by its <see cref="ILanguage.Id"/>.
	/// </summary>
	/// <param name="id">The ID of the language.</param>
	/// <returns>The <see cref="ILanguage"/> instance with the requested ID.</returns>
	/// <exception cref="LanguageNotFoundException">If the given <paramref name="id"/> does not belong to any available language.</exception>
	ILanguage GetById(Guid id)
		=> GetAll().FirstOrDefault(l => l.Id == id) ?? throw LanguageNotFoundException.ById(id);

	/// <summary>
	/// Tries to find a <see cref="ILanguage"/> by its <see cref="ILanguage.Name"/>.
	/// </summary>
	/// <param name="name">The name of the language.</param>
	/// <param name="comparison">The comparison type to use.</param>
	/// <returns>A language with the given name or <see langword="null"/>, if no language with a matching name could be found.</returns>
	ILanguage? GetByName(string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
		=> GetAll().FirstOrDefault(l => l.Name.Equals(name, comparison));
}
