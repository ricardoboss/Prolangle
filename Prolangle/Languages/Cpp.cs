using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Cpp : BaseLanguage
{
	private Cpp()
	{
	}

	public static Cpp Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "C++";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Nominal | TypeSystem.Inferred;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public override Applications KnownForBuilding { get; } = Applications.System | Applications.Games | Applications.General;
	public override Paradigms Paradigms { get; } = Paradigms.Procedural | Paradigms.Imperative | Paradigms.Functional | Paradigms.ObjectOriented | Paradigms.Generic;
	public override double? TiobeRating { get; } = 10.01;
	public override int AppearanceYear { get; } = 1985;
}
