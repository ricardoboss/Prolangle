using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Step : BaseLanguage
{
	private Step()
	{
	}

	public static Step Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "STEP";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Manifest;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public override Applications KnownForBuilding { get; } = Applications.General;
	public override Paradigms Paradigms { get; } = Paradigms.Functional | Paradigms.Declarative | Paradigms.Structured;
	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 2022;
}
