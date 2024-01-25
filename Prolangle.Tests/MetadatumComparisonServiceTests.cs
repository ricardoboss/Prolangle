using Prolangle.Languages.Framework;
using Prolangle.Services;
using MatchType = Prolangle.Models.MatchType;

namespace Prolangle.Tests;

public class MetadatumComparisonServiceTests
{
	private LanguagesProvider LanguagesProvider { get; } = new();

	[Theory]
	[InlineData("C#", "Pascal", TypeSystem.Safe | TypeSystem.Strong | TypeSystem.Static)]
	[InlineData("AppleScript", "SQL", TypeSystem.None)]
	[InlineData("Java", "Java",  TypeSystem.Safe | TypeSystem.Strong | TypeSystem.Static | TypeSystem.Manifest | TypeSystem.Nominal)]
	public void TestTypingOverlap(string thisLanguageName, string thatLanguageName, TypeSystem expectedOverlap)
	{
		ILanguage thisLanguage = LanguagesProvider.Languages.Single(l => l.Name == thisLanguageName);
		ILanguage thatLanguage = LanguagesProvider.Languages.Single(l => l.Name == thatLanguageName);

		TypeSystem overlap = new MetadatumComparisonService(thisLanguage).TypingOverlap(thatLanguage);

		Assert.Equal(expectedOverlap, overlap);
	}

	[Theory]
	[InlineData("SQL", "SQL", MatchType.Exact)]
	public void TestApplicationsMatch(string thisLanguageName, string thatLanguageName, MatchType expectedMatchType)
	{
		ILanguage thisLanguage = LanguagesProvider.Languages.Single(l => l.Name == thisLanguageName);
		ILanguage thatLanguage = LanguagesProvider.Languages.Single(l => l.Name == thatLanguageName);

		MatchType matchType = new MetadatumComparisonService(thisLanguage).ApplicationsMatch(thatLanguage);

		Assert.Equal(expectedMatchType, matchType);
	}
}
