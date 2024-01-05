namespace Prolangle.Models;

public record PlayedGame(Guid TargetLanguageId)
{
	public List<Guid> Guesses { get; private set; } = [];
	public bool Won { get; set; }
}
