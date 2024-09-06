using System.Text.Json;
using System.Text.Json.Serialization;
using Prolangle.Interfaces;
using Prolangle.Languages.Framework;

namespace Prolangle.Serialization;

public class LanguageConverter(ILanguagesProvider languagesProvider) : JsonConverter<ILanguage>
{
	public override ILanguage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var name = reader.GetString();

		return name is null ? null : GetLanguageByName(name);
	}

	public override void Write(Utf8JsonWriter writer, ILanguage value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.Name);
	}

	private ILanguage GetLanguageByName(string name)
	{
		return languagesProvider.PropertiesGameLanguages.Single(l => l.Name == name);
	}
}
