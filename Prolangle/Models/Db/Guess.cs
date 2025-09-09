using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prolangle.Models.Db;

[Table("Guesses")]
internal sealed class Guess
{
	public const string StoreName = "Guesses";

	[Key, Required]
	public required Guid GameId { get; set; }

	[Required]
	public required DateTimeOffset PlayedAt { get; set; }

	[Required]
	public required Guid LanguageId { get; set; }

	public override string ToString()
	{
		return $"Guess {{ GameId = {GameId}, PlayedAt = {PlayedAt:s}, LanguageId = {LanguageId} }}";
	}
}
