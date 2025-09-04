namespace Prolangle.Abstractions.Services;

public interface ILanguageMetadataProvider
{
	string? GetDescription<TEnum>(TEnum value) where TEnum : Enum;

	Uri? GetMoreInfoUrl<TEnum>(TEnum value) where TEnum : Enum;
}
