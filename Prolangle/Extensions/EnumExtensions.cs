using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Prolangle.Extensions;

internal static class EnumExtensions
{
	private static string? GetDisplayName<TEnum>(this TEnum value)
		where TEnum : System.Enum
	{
		var memberInfo = typeof(TEnum).GetMember(value.ToString());
		var enumValueMemberInfo = memberInfo.FirstOrDefault(m => m.DeclaringType == typeof(TEnum));
		var attr = enumValueMemberInfo?.GetCustomAttribute<DisplayAttribute>();

		return attr?.Name;
	}

	public static string GetDisplayNameOrFallback<TEnum>(this TEnum value)
		where TEnum : System.Enum
	{
		return value.GetDisplayName() ?? value.ToString();
	}
}
