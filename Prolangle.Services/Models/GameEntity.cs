using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prolangle.Services.Models;

[Table("Games")]
public sealed class GameEntity
{
	[Key, Required]
	public required Guid Id { get; set; }

	[Required]
	public required DateTimeOffset PlayedAt { get; set; }

	[Required]
	public required uint Seed { get; set; }

	[Required]
	public required Guid SolutionId { get; set; }

	[Required]
	public required Guid TypeId { get; set; }

	public override string ToString()
	{
		return $"GameEntity {{ Id = {Id}, GameSeed = {Seed}, PlayedAt = {PlayedAt:s}, TypeId = {TypeId} }}";
	}
}
