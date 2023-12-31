using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Javascript : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "JavaScript";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak | TypeSystem.Duck;
	public override bool Compiled { get; } = false;
	public override bool GarbageCollected { get; } = true;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public override Applications KnownForBuilding { get; } = Applications.Client | Applications.Server | Applications.Web;
	public override Paradigms Paradigms { get; } = Paradigms.EventDriven | Paradigms.Functional | Paradigms.Imperative | Paradigms.Procedural | Paradigms.ObjectOriented;
	public override double? TiobeRating { get; } = 2.9;
	public override int AppearanceYear { get; } = 1995;
}
