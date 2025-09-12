using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Bash : BaseLanguage
{
	private Bash()
	{
	}

	public static Bash Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("1ebfba11-e4df-43fd-b87d-8ea9737054a6");
	public override string Name { get; } = "Bash";

	public override TypeSystem Typing { get; } =
		TypeSystem.Weak | TypeSystem.Dynamic;

	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } =
		Applications.Scripts;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Procedural |
	                                               Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.21;
	public override int AppearanceYear { get; } = 1989;
}
