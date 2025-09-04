using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public interface ILanguageChooser
{
	ILanguage ChooseLanguage(GameSeed? seed = null);
}
