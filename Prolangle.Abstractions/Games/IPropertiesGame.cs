using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Games;

public interface IPropertiesGame : IGuessGame<ILanguage, IPropertiesGameGuess, ILanguage>;

public interface IPropertiesGameGuess : IGuess<ILanguage>;
