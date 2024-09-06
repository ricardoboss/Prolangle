using System.Collections.Immutable;
using System.Reflection;
using NetArchTest.Rules;
using Prolangle.Languages.Framework;
using Prolangle.Services;

namespace Prolangle.Tests;

public class LanguageTests
{
	[Fact]
	public void AllLanguagesInheritBaseLanguage()
	{
		ConditionList? allInheritBaseLanguage =
			Types.InAssembly(typeof(BaseLanguage).Assembly)
				.That().ResideInNamespace("Prolangle.Languages")
				.And().DoNotResideInNamespaceStartingWith("Prolangle.Languages.")
				.Should().Inherit(typeof(BaseLanguage));

		Assert.True(allInheritBaseLanguage.GetResult().IsSuccessful);
	}

	[Fact]
	public void AllLanguageConstructorsArePrivate()
	{
		IEnumerable<ConstructorInfo> constructors =
			Types.InAssembly(typeof(BaseLanguage).Assembly)
				.That().Inherit(typeof(BaseLanguage))
				.GetTypes()
				.SelectMany(
					t => t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));

		Assert.True(constructors.All(ctor => !ctor.IsPublic));
	}

	/// <summary>
	/// For now, the properties game (and therefore LanguagesProvider) will
	/// always offer _all_ languages (unlike the snippets game), so we expect
	/// these counts to match.
	/// </summary>
	[Fact]
	public void LanguagesProviderMatchesCount()
	{
		var expectedLanguages = Types.InAssembly(typeof(BaseLanguage).Assembly)
			.That().Inherit(typeof(BaseLanguage))
			.GetTypes();

		var providedLanguages = new LanguagesProvider().PropertiesGameLanguages;

		Assert.Equal(expectedLanguages.Count(), providedLanguages.Count());
	}

	[Fact]
	public void LanguageNamesAreUnique()
	{
		var types = Types.InAssembly(typeof(BaseLanguage).Assembly)
			.That().Inherit(typeof(BaseLanguage))
			.GetTypes()
			.ToImmutableList();

		var languageNames = types
			.Select(t => ((BaseLanguage)Activator.CreateInstance(t, nonPublic: true))!.Name)
			.Distinct();

		Assert.Equal(types.Count, languageNames.Count());
	}
}
