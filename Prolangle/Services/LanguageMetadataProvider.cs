using System.ComponentModel;
using System.Reflection;
using Prolangle.Languages.Framework;

namespace Prolangle.Services;

public class LanguageMetadataProvider
{
	public string? ResolveDescription<TEnum>(TEnum value)
		where TEnum : System.Enum
	{
		var memberInfo = typeof(TEnum).GetMember(value.ToString());
		var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(TEnum));
		var attr = enumValueMemberInfo?.GetCustomAttribute<DescriptionAttribute>();

		return attr?.Description ?? null;
	}

	public string? ResolveMoreInfoUrl<TEnum>(TEnum value)
		where TEnum : Enum
	{
		var memberInfo = typeof(TEnum).GetMember(value.ToString());
		var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(TEnum));
		var attr = enumValueMemberInfo?.GetCustomAttribute<MoreInformationUrlAttribute>();

		return attr?.Url ?? null;
	}
}
