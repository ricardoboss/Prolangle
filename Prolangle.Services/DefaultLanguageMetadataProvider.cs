using System.ComponentModel;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;

namespace Prolangle.Services;

public class DefaultLanguageMetadataProvider : ILanguageMetadataProvider
{
	public string? GetDescription<TEnum>(TEnum value)
		where TEnum : Enum
	{
		var memberInfo = typeof(TEnum).GetMember(value.ToString());
		var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(TEnum));
		var attr = enumValueMemberInfo?.GetCustomAttribute<DescriptionAttribute>();

		return attr?.Description ?? null;
	}

	public Uri? GetMoreInfoUrl<TEnum>(TEnum value)
		where TEnum : Enum
	{
		var memberInfo = typeof(TEnum).GetMember(value.ToString());
		var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(TEnum));
		var attr = enumValueMemberInfo?.GetCustomAttribute<MoreInformationUrlAttribute>();

		var rawUrl = attr?.Url ?? null;
		if (rawUrl == null)
			return null;

		return new(rawUrl);
	}
}

public static class DefaultLanguageMetadataProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddDefaultLanguageMetadataProvider(this IServiceCollection services)
	{
		services.AddSingleton<ILanguageMetadataProvider, DefaultLanguageMetadataProvider>();

		return services;
	}
}
