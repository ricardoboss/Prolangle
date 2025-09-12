using Prolangle.Abstractions.Languages;

namespace Prolangle.Services.Tests;

public class LanguageMetadataProviderTests
{
	[Theory]
	[InlineData(Applications.Other, false)]
	[InlineData(Applications.Configuration, true)]
	public void TestDescription(Applications enumValue, bool expectNonEmptyResult)
	{
		var provider = new DefaultLanguageMetadataProvider();
		var result = provider.GetDescription(enumValue);

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
		var provider = new DefaultLanguageMetadataProvider();
		var result = provider.GetMoreInfoUrl(enumValue);

		if (expectNonEmptyResult)
		{
			Assert.NotNull(result);
			Assert.NotEmpty(result.AbsoluteUri);
		}
		else
		{
			Assert.Null(result);
		}
	}
}
