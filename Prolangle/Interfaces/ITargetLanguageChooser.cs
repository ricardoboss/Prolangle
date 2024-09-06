using Prolangle.Languages.Framework;
using Prolangle.Models;

namespace Prolangle.Interfaces;

public interface ITargetLanguageChooser
{
	ILanguage ChooseTargetLanguage(IEnumerable<ILanguage> availableLanguages, GameSeed seed, int seedOffset);
}
