using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class JavaScript : BaseLanguage
{
	private JavaScript()
	{
	}

	public static JavaScript Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("d164d006-a6bd-4460-9401-0eef90adcf4b");
	public override string Name { get; } = "JavaScript";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak | TypeSystem.Duck;
	public override bool Compiled { get; }
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
