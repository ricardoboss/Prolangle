using Prolangle.Abstractions.Games;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Abstractions.Services;

public interface ISnippetsGameGuessTracker : IGuessTracker<ISnippetsGame, ICodeSnippet, ISnippetsGameGuess, ILanguage>;
