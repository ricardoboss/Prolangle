using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Basic : BaseLanguage
{
	private Basic()
	{
	}

	public static Basic Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "BASIC";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;
	public override Applications KnownForBuilding { get; } = Applications.Education | Applications.General;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative;
	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1964;
}
