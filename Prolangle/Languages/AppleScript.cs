using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class AppleScript : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "AppleScript";
	public override TypeSystem Typing { get; } = TypeSystem.Weak | TypeSystem.Dynamic;
	public override bool Compiled { get; } = true;
	public override bool GarbageCollected { get; } = true;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;
	public override Applications KnownForBuilding { get; } = Applications.Apple | Applications.Other;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Structured |
	                                               Paradigms.EventDriven | Paradigms.ObjectOriented;

	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1993;
}
