namespace Prolangle.Abstractions.Languages;

[AttributeUsage(AttributeTargets.Field)]

public sealed class MoreInformationUrlAttribute(string url) : Attribute
{
	public string Url { get; } = url;
}
