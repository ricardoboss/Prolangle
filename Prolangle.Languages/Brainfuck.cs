using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Brainfuck : BaseLanguage
{
	private Brainfuck()
	{
	}

	public static Brainfuck Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("25491faa-6a2c-4ce4-93e9-103841a12f87");
	public override string Name { get; } = "Brainfuck";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } =
		Applications.None;

	public override Paradigms Paradigms { get; } = Paradigms.Esoteric | Paradigms.Imperative |
	                                               Paradigms.Structured;

	public override double? TiobeRating { get; }
	public override int AppearanceYear { get; } = 1993;
}
