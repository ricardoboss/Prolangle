using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Batch : BaseLanguage
{
	private Batch()
	{
	}

	public static Batch Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("9577f4a2-fd9e-4b4b-bdd8-65e08b6cc5d5");
	public override string Name { get; } = "Batch";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;
	public override Applications KnownForBuilding { get; } = Applications.Scripts;
	public override Paradigms Paradigms { get; } = Paradigms.Structured | Paradigms.Imperative;
	public override double? TiobeRating { get; }
	public override int AppearanceYear { get; } = 1981;
}
