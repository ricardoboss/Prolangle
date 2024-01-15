using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class VisualBasicClassic : BaseLanguage
{
	private VisualBasicClassic()
	{
	}

	public static VisualBasicClassic Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Visual Basic (classic)";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.ReferenceCounting;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Client | Applications.Desktop |
	                                                         Applications.Microsoft;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectBased | Paradigms.EventDriven;

	public override double? TiobeRating { get; } = 1.60;
	public override int AppearanceYear { get; } = 1991;
}
