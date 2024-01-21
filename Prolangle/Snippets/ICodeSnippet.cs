using Prolangle.Languages.Framework;

namespace Prolangle.Snippets;

public interface ICodeSnippet
{
	/// <summary>
	/// The language <see cref="SourceCode"/> is written in, and also
	/// consequently the language the user needs to guess to win the game.
	/// </summary>
	ILanguage Language { get; }

	/// <summary>
	/// The file name for this code snippet. Will be revealed when the user has
	/// won.
	/// </summary>
	string Filename { get; }

	/// <summary>
	/// The source code, in raw form.
	/// </summary>
	string SourceCode { get; }
}
