namespace Prolangle.Languages.Framework;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]

sealed class MoreInformationUrlAttribute(string url) : Attribute
{
	public string Url { get; } = url;
}
