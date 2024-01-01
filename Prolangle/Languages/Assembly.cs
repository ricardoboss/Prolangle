using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Assembly : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Assembly";

	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = true;
	public override bool GarbageCollected { get; } = false;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Assembly;

	public override Applications KnownForBuilding { get; } = Applications.System | Applications.General | Applications.Games;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative;
	public override double? TiobeRating { get; } = 1.11;
	public override int AppearanceYear { get; } = 1947;
}
