using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Sql : BaseLanguage
{
	private Sql()
	{
	}

	public static Sql Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "SQL";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong ;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.None;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;

	public override double? TiobeRating { get; } = 1.61;
	public override int AppearanceYear { get; } = 1974;
}
