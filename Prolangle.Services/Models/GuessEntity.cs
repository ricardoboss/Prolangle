using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prolangle.Services.Models;

[Table("Guesses")]
public sealed class GuessEntity
{
	[Key, Required]
	public required Guid GameId { get; set; }

	[Required]
	public required DateTimeOffset PlayedAt { get; set; }

	[Required]
	public required Guid LanguageId { get; set; }

	public override string ToString()
	{
		return $"GuessEntity {{ GameId = {GameId}, PlayedAt = {PlayedAt:s}, LanguageId = {LanguageId} }}";
	}
}
