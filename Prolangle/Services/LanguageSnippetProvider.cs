using Prolangle.Languages;
using Prolangle.Languages.Framework;
using Prolangle.Snippets;
using Prolangle.Snippets.AppleScript;
using Prolangle.Snippets.CSharp;
using Prolangle.Snippets.Php;

namespace Prolangle.Services;

public class LanguageSnippetProvider(Func<int> seedGenerator)
{
	public static IReadOnlyList<ILanguage> SupportedLanguages =>
	[
		AppleScript.Instance,
		CSharp.Instance,
		Php.Instance,
	];

	public ICodeSnippet GetSnippet(ILanguage language)
	{
		var random = new Random(seedGenerator());

		if (language.Id == AppleScript.Instance.Id)
			return GetAppleScriptSnippet();

		if (language.Id == CSharp.Instance.Id)
			return GetCSharpSnippet(random);

		if (language.Id == Php.Instance.Id)
			return GetPhpSnippet();

		throw new NotSupportedException("Language not supported");
	}

	private static SimpleAppleScriptSnippet GetAppleScriptSnippet() => new();

	private static ICodeSnippet GetCSharpSnippet(Random random)
	{
		ICodeSnippet[] snippets = [
			new SimpleCSharpSnippet(),
			new TaskCSharpSnippet(),
		];

		var index = random.Next(snippets.Length);

		return snippets[index];
	}

	private static SimplePhpSnippet GetPhpSnippet() => new();
}
