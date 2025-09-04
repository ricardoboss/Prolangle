using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Sql : BaseLanguage
{
	private Sql()
	{
	}

	public static Sql Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("e063d9c3-7caf-4da7-ab5e-557cb266f093");
	public override string Name { get; } = "SQL";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong ;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.None;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;

	public override double? TiobeRating { get; } = 1.61;
	public override int AppearanceYear { get; } = 1974;
}
