using Prolangle.Languages.Framework;
using Prolangle.Services;

namespace Prolangle.Tests;

public class LanguageMetadataProviderTests
{
	[Theory]
	[InlineData(Applications.Other, false)]
	[InlineData(Applications.Configuration, true)]
	public void TestDescription(Applications enumValue, bool expectNonEmptyResult)
	{
		var provider = new LanguageMetadataProvider();
		var result = provider.ResolveDescription(enumValue);

		if (expectNonEmptyResult)
		{
			Assert.NotNull(result);
			Assert.NotEmpty(result);
		}
		else
		{
			Assert.Null(result);
		}
	}

	[Theory]
	[InlineData(MemoryManagement.Other, false)]
	[InlineData(MemoryManagement.TracingGarbageCollection, true)]
	public void TestMoreInfoUrl(MemoryManagement enumValue, bool expectNonEmptyResult)
	{
		var provider = new LanguageMetadataProvider();
		var result = provider.ResolveMoreInfoUrl(enumValue);

		if (expectNonEmptyResult)
		{
			Assert.NotNull(result);
			Assert.NotEmpty(result);
		}
		else
		{
			Assert.Null(result);
		}
	}
}
