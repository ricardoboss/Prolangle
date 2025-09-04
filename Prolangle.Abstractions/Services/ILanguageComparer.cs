using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public interface ILanguageComparer
{
	LanguageComparison Compare(ILanguage left, ILanguage right);
}
