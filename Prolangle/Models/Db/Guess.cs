namespace Prolangle.Models.Db;

public class Guess
{
	public const string StoreName = "Guesses";

	public required Guid GameId { get; set; }

	public required DateTimeOffset PlayedAt { get; set; }

	public required Guid LanguageId { get; set; }

	public override string ToString()
	{
		return $"Guess {{ GameId = {GameId}, PlayedAt = {PlayedAt:s}, LanguageId = {LanguageId} }}";
	}
}
