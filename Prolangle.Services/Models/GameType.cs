using Vogen;

namespace Prolangle.Services.Models;

[ValueObject<Guid>]
[Instance("PropertiesGameTypeId", "Guid.Parse(\"ef5aa970-d19a-4902-aca3-1b00296b9cf9\")")]
[Instance("SnippetsGameTypeId", "Guid.Parse(\"ab67e88d-cf20-4836-a931-65cf6a22695a\")")]
public readonly partial struct GameType;
