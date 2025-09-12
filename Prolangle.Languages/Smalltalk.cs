using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Smalltalk : BaseLanguage
{
	private Smalltalk()
	{
	}

	public static Smalltalk Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("f91b854e-c899-4963-a0e6-706919b4bf3e");
	public override string Name { get; } = "Smalltalk";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Smalltalk;
	public override Applications KnownForBuilding { get; } = Applications.Desktop | Applications.General;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented |
	                                               Paradigms.Imperative |
	                                               Paradigms.Reflective;

	public override double? TiobeRating { get; }
	public override int AppearanceYear { get; } = 1972;
}
