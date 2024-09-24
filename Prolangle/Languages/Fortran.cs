using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Fortran : BaseLanguage
{
	private Fortran()
	{
	}

	public static Fortran Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Fortran";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Manifest;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.General;

	public override Paradigms Paradigms { get; } = Paradigms.Structured | Paradigms.Procedural;

	public override double? TiobeRating { get; } = 1.78;
	public override int AppearanceYear { get; } = 1957;
}
