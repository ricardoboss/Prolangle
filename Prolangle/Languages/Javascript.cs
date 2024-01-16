using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Javascript : BaseLanguage
{
	private Javascript()
	{
	}

	public static Javascript Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "JavaScript";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak | TypeSystem.Duck;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } = Applications.Client | Applications.Configuration |
	                                                         Applications.Server | Applications.Web |
	                                                         Applications.Scripts;

	public override Paradigms Paradigms { get; } = Paradigms.EventDriven | Paradigms.Functional | Paradigms.Imperative |
	                                               Paradigms.Procedural | Paradigms.ObjectOriented;

	public override double? TiobeRating { get; } = 2.9;
	public override int AppearanceYear { get; } = 1995;
}
