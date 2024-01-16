using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class CSharp : BaseLanguage
{
	private CSharp()
	{
	}

	public static CSharp Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "C#";

	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Dynamic |
	                                             TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Inferred;

	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } = Applications.Microsoft | Applications.Web |
	                                                         Applications.Desktop | Applications.Client |
	                                                         Applications.Server | Applications.General |
	                                                         Applications.Games;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented | Paradigms.Functional |
	                                               Paradigms.Structured | Paradigms.Imperative | Paradigms.Generic |
	                                               Paradigms.Reflective | Paradigms.EventDriven | Paradigms.TaskDriven |
	                                               Paradigms.Concurrent;

	public override double? TiobeRating { get; } = 7.3;
	public override int AppearanceYear { get; } = 2000;
}
