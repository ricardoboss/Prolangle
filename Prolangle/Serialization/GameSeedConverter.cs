using System.Text.Json;
using System.Text.Json.Serialization;
using Prolangle.Models;

namespace Prolangle.Serialization;

public class GameSeedConverter : JsonConverter<GameSeed>
{
	public override GameSeed Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var intSeed = reader.GetInt32();

		return (GameSeed)intSeed;
	}

	public override void Write(Utf8JsonWriter writer, GameSeed value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue((int)value);
	}
}
