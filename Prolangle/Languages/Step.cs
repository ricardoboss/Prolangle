using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Step : ILanguage
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; } = "STEP";
	public TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Manifest;
	public bool Compiled { get; } = false;
	public bool GarbageCollected { get; } = true;
	public SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public Applications KnownForBuilding { get; } = Applications.General;
	public Paradigms Paradigms { get; } = Paradigms.Functional | Paradigms.Declarative | Paradigms.Structured;
	public double? TiobeRating { get; } = null;
	public int AppearanceYear { get; } = 2022;
}
