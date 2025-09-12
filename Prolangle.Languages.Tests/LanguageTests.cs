using System.Collections.Immutable;
using System.Reflection;
using NetArchTest.Rules;

namespace Prolangle.Languages.Tests;

public class LanguageTests
{
	[Fact]
	public void AllLanguagesInheritBaseLanguage()
	{
		var allInheritBaseLanguage =
			Types.InAssembly(typeof(BaseLanguage).Assembly)
				.That().ResideInNamespace("Prolangle.Languages")
				.And().AreNotAbstract()
				.Should().Inherit(typeof(BaseLanguage));

		Assert.True(allInheritBaseLanguage.GetResult().IsSuccessful);
	}

	[Fact]
	public void AllLanguageConstructorsArePrivate()
	{
		var constructors =
			Types.InAssembly(typeof(BaseLanguage).Assembly)
				.That().Inherit(typeof(BaseLanguage))
				.And().AreNotAbstract()
				.GetTypes()
				.SelectMany(
					t => t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));

		Assert.True(constructors.All(ctor => !ctor.IsPublic));
	}

	[Fact]
	public void LanguageNamesAreUnique()
	{
		var types = Types.InAssembly(typeof(BaseLanguage).Assembly)
			.That().Inherit(typeof(BaseLanguage))
			.And().AreNotAbstract()
			.GetTypes()
			.ToImmutableList();

		var languageNames = types
			.Select(t => ((BaseLanguage)Activator.CreateInstance(t, nonPublic: true)!).Name)
			.Distinct();

		Assert.Equal(types.Count, languageNames.Count());
	}
}
