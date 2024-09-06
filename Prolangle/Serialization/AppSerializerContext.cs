using System.Text.Json.Serialization;
using Prolangle.Services;

namespace Prolangle.Serialization;

[JsonSerializable(typeof(Dictionary<int, PropertiesGuessGame>))]
[JsonSerializable(typeof(Dictionary<int, SnippetsGuessGame>))]
public partial class AppSerializerContext : JsonSerializerContext;
