using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public interface
	IPropertiesGameGuessTracker : IGuessTracker<IPropertiesGame, ILanguage, IPropertiesGameGuess, ILanguage>;
