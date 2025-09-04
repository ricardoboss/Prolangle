using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using MatchType = Prolangle.Abstractions.Services.MatchType;

namespace Prolangle.Services.Tests;

public static class PropertiesLanguageComparerTests
{
	private static ILanguage GetLanguageByName(string name)
	{
		return ((ILanguagesProvider)new AssemblyLanguagesProvider()).GetByName(name) ??
		       throw new LanguageNotFoundException($"Language with name '{name}' does not exist");
	}

	[Theory]
	[InlineData("C#", "Pascal", TypeSystem.Safe | TypeSystem.Strong | TypeSystem.Static)]
	[InlineData("AppleScript", "SQL", TypeSystem.None)]
	[InlineData("Java", "Java",
		TypeSystem.Safe | TypeSystem.Strong | TypeSystem.Static | TypeSystem.Manifest | TypeSystem.Nominal)]
	public static void TestTypingOverlap(string thisLanguageName, string thatLanguageName, TypeSystem expectedOverlap)
	{
		var thisLanguage = GetLanguageByName(thisLanguageName);
		var thatLanguage = GetLanguageByName(thatLanguageName);

		var comparison = new PropertiesLanguageComparer().Compare(thisLanguage, thatLanguage);

		Assert.Equal(expectedOverlap, comparison.TypeSystem);
	}

	[Theory]
	[InlineData("SQL", "SQL", MatchType.Exact)]
	public static void TestApplicationsMatch(string thisLanguageName, string thatLanguageName, MatchType expectedMatchType)
	{
		var thisLanguage = GetLanguageByName(thisLanguageName);
		var thatLanguage = GetLanguageByName(thatLanguageName);

		var comparison = new PropertiesLanguageComparer().Compare(thisLanguage, thatLanguage);

		Assert.Equal(expectedMatchType, comparison.ApplicationsMatch);
	}
}
