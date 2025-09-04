namespace Prolangle.Models.Db;

public class Game
{
	public const string StoreName = "Games";

	public required Guid Id { get; set; }

	public required DateTimeOffset PlayedAt { get; set; }

	public required int Seed { get; set; }

	public required Guid SolutionId { get; set; }

	public Guid? SecondarySolutionId { get; set; }

	public required Guid TypeId { get; set; }

	public override string ToString()
	{
		return $"Game {{ Id = {Id}, GameSeed = {Seed}, PlayedAt = {PlayedAt:s}, TypeId = {TypeId} }}";
	}
}
