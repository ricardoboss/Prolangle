using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Batch : BaseLanguage
{
	private Batch()
	{
	}

	public static Batch Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Batch";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;
	public override Applications KnownForBuilding { get; } = Applications.Scripts;
	public override Paradigms Paradigms { get; } = Paradigms.Structured | Paradigms.Imperative;
	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1981;
}
