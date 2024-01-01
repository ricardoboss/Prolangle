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
			yield return new AppleScript();
			yield return new Assembly();
			yield return new C();
			yield return new Cpp();
			yield return new CSharp();
			yield return new Css();
			yield return new Dart();
			yield return new Go();
			yield return new Html();
			yield return new Java();
			yield return new Javascript();
			yield return new Pascal();
			yield return new Perl();
			yield return new Php();
			yield return new Python();
			yield return new Ruby();
			yield return new Sql();
			yield return new Step();
			yield return new Swift();
		}
	}
}
