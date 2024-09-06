using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;

namespace Prolangle.Services;

public class PropertiesGuessGame(
	GameSeed seed,
	ILanguage targetLanguage,
	List<ILanguage> guesses,
	IReadOnlyCollection<ILanguage> availableLanguages
) : BaseGuessGame(seed, targetLanguage, guesses, availableLanguages), IPropertiesGuessGame;
