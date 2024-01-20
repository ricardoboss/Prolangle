using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class PowerShell : BaseLanguage
{
	private PowerShell()
	{
	}

	public static PowerShell Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "PowerShell";

	public override TypeSystem Typing { get; } =
		TypeSystem.Strong | TypeSystem.Safe | TypeSystem.Dynamic | TypeSystem.Inferred;

	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } =
		Applications.General | Applications.Scripts | Applications.Microsoft;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.ObjectOriented |
	                                               Paradigms.Functional | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.24;
	public override int AppearanceYear { get; } = 2006;
}
