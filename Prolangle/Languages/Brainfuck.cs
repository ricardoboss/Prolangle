using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Brainfuck : BaseLanguage
{
	private Brainfuck()
	{
	}

	public static Brainfuck Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Brainfuck";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } =
		Applications.None;

	public override Paradigms Paradigms { get; } = Paradigms.Esoteric | Paradigms.Imperative |
	                                               Paradigms.Structured;

	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1993;
}
