using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Scratch : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name => "Scratch";
	public override TypeSystem Typing => TypeSystem.Structural | TypeSystem.Dynamic | TypeSystem.Safe;
	public override bool Compiled => false;
	public override MemoryManagement MemoryManagement => MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle => SyntaxStyle.Visual;
	public override Applications KnownForBuilding => Applications.Games | Applications.Fun | Applications.Education;
	public override Paradigms Paradigms => Paradigms.EventDriven | Paradigms.BlockBased | Paradigms.ObjectOriented;
	public override double? TiobeRating => 1.44;
	public override int AppearanceYear => 2007;
}
