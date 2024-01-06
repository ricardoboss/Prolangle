namespace Prolangle.Models.Game;

public record PropertyGuessingGameInstance(Guid TargetLanguageId) : GameInstance
{
	public List<Guid> Guesses { get; private set; } = [];
}
