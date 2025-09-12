using NetArchTest.Rules;
using Prolangle.Languages;

namespace Prolangle.Services.Tests;

public static class AssemblyLanguagesProviderTest
{
	/// <summary>
	/// For now, the properties game (and therefore LanguagesProvider) will
	/// always offer _all_ languages (unlike the snippets game), so we expect
	/// these counts to match.
	/// </summary>
	[Fact]
	public static void LanguagesProviderMatchesCount()
	{
		var expectedLanguages = Types.InAssembly(typeof(BaseLanguage).Assembly)
			.That().Inherit(typeof(BaseLanguage))
			.And().AreNotAbstract()
			.GetTypes();

		var provider = new AssemblyLanguagesProvider();
		var providedLanguages = provider.GetAll();

		Assert.Equal(expectedLanguages.Count(), providedLanguages.Count());
	}
}
