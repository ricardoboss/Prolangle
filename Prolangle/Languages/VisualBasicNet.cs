using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class VisualBasicNet : BaseLanguage
{
	private VisualBasicNet()
	{
	}

	public static VisualBasicNet Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Visual Basic (.NET)";

	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Inferred |
	                                             TypeSystem.Weak | TypeSystem.Nominal;

	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Client | Applications.Desktop |
	                                                         Applications.Microsoft | Applications.Server |
	                                                         Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented |
	                                               Paradigms.Imperative | Paradigms.Concurrent |
	                                               Paradigms.EventDriven | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 1.60;
	public override int AppearanceYear { get; } = 2001;
}
