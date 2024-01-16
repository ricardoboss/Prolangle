using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class AppleScript : BaseLanguage
{
	private AppleScript()
	{
	}

	public static AppleScript Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "AppleScript";
	public override TypeSystem Typing { get; } = TypeSystem.Weak | TypeSystem.Dynamic;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } =
		Applications.Apple | Applications.Other | Applications.Scripts;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Structured |
	                                               Paradigms.EventDriven | Paradigms.ObjectOriented |
	                                               Paradigms.NaturalLanguage;

	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1993;
}
