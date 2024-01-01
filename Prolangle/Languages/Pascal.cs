using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Pascal : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Pascal";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.GarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Pascal;
	public override Applications KnownForBuilding { get; } = Applications.Education | Applications.Desktop;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Structured | Paradigms.Procedural | Paradigms.ObjectOriented | Paradigms.Generic;
	public override double? TiobeRating { get; } = 0.92;
	public override int AppearanceYear { get; } = 1970;
}
