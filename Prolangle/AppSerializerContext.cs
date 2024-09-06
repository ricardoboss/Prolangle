using System.Text.Json.Serialization;
using Prolangle.Interfaces;
using Prolangle.Languages.Framework;
using Prolangle.Models;
using Prolangle.Services;

namespace Prolangle;

[JsonSerializable(typeof(Dictionary<int, PropertiesGuessGame>))]
[JsonSerializable(typeof(Dictionary<int, SnippetsGuessGame>))]
public partial class AppSerializerContext : JsonSerializerContext;
