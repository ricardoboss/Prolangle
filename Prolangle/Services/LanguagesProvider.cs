using System.Data;
using Prolangle.Languages;
using Prolangle.Languages.Framework;

namespace Prolangle.Services;

public class LanguagesProvider
{
	private readonly Lazy<IReadOnlyList<ILanguage>> languages = new(() => LanguageEnumerable.ToList());

	public IReadOnlyList<ILanguage> Languages => languages.Value;

	private static IEnumerable<ILanguage> LanguageEnumerable
	{
		get
		{
			yield return AppleScript.Instance;
			yield return Assembly.Instance;
			yield return Bash.Instance;
			yield return Basic.Instance;
			yield return Batch.Instance;
			yield return Brainfuck.Instance;
			yield return C.Instance;
			yield return Cpp.Instance;
			yield return CSharp.Instance;
			yield return Cobol.Instance;
			yield return Css.Instance;
			yield return Dart.Instance;
			yield return Go.Instance;
			yield return Html.Instance;
			yield return Java.Instance;
			yield return Javascript.Instance;
			yield return Lua.Instance;
			yield return Markdown.Instance;
			yield return ObjectiveC.Instance;
			yield return Pascal.Instance;
			yield return Perl.Instance;
			yield return Php.Instance;
			yield return PowerShell.Instance;
			yield return Python.Instance;
			yield return Ruby.Instance;
			yield return Rust.Instance;
			yield return Scratch.Instance;
			yield return Smalltalk.Instance;
			yield return Sql.Instance;
			yield return Step.Instance;
			yield return Swift.Instance;
			yield return VisualBasicClassic.Instance;
			yield return VisualBasicNet.Instance;
			yield return Xml.Instance;
		}
	}
}
