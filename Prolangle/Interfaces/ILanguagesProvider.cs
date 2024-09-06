using Prolangle.Languages.Framework;

namespace Prolangle.Interfaces;

public interface ILanguagesProvider
{
	IReadOnlyList<ILanguage> PropertiesGameLanguages { get; }

	IReadOnlyList<ILanguage> SnippetsGameLanguages { get; }
}
