using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Go : BaseLanguage
{
	private Go()
	{
	}

	public static Go Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("df50bed7-c9d8-4356-ba8a-9cf916a1ea9f");
	public override string Name { get; } = "Go";

	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Inferred | TypeSystem.Strong |
	                                             TypeSystem.Structural | TypeSystem.Nominal;

	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } =
		Applications.Web | Applications.Server | Applications.General;

	public override Paradigms Paradigms { get; } = Paradigms.Concurrent | Paradigms.Imperative | Paradigms.Functional |
	                                               Paradigms.ObjectOriented;

	public override double? TiobeRating { get; } = 1.03;
	public override int AppearanceYear { get; } = 2009;
}
