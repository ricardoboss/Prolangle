using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prolangle.Models.Db;

[Table("Games")]
internal sealed class Game
{
	public const string StoreName = "Games";

	[Key, Required]
	public required Guid Id { get; set; }

	[Required]
	public required DateTimeOffset PlayedAt { get; set; }

	[Required]
	public required int Seed { get; set; }

	[Required]
	public required Guid SolutionId { get; set; }

	public Guid? SecondarySolutionId { get; set; }

	[Required]
	public required Guid TypeId { get; set; }

	public override string ToString()
	{
		return $"Game {{ Id = {Id}, GameSeed = {Seed}, PlayedAt = {PlayedAt:s}, TypeId = {TypeId} }}";
	}
}
