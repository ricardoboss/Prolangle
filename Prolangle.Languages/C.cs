using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class C : BaseLanguage
{
	private C()
	{
	}

	public static C Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("2f608e2f-97e7-4b4d-8aa7-6ddff6283c64");
	public override string Name { get; } = "C";

	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Weak | TypeSystem.Manifest | TypeSystem.Nominal;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } = Applications.System | Applications.General | Applications.Games;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Procedural | Paradigms.Structured;
	public override double? TiobeRating { get; } = 11.44;
	public override int AppearanceYear { get; } = 1972;
}
