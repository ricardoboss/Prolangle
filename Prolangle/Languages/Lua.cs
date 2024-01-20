using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Lua : BaseLanguage
{
	private Lua()
	{
	}

	public static Lua Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name => "Lua";
	public override TypeSystem Typing => TypeSystem.Weak | TypeSystem.Dynamic | TypeSystem.Duck;
	public override bool Compiled => false;
	public override MemoryManagement MemoryManagement => MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle => SyntaxStyle.Other;
	public override Applications KnownForBuilding => Applications.General | Applications.Games | Applications.Scripts;

	public override Paradigms Paradigms =>
		Paradigms.Imperative | Paradigms.Procedural |
		Paradigms.ObjectOriented | Paradigms.Functional |
		Paradigms.Reflective;

	public override double? TiobeRating => 0.37;
	public override int AppearanceYear => 1993;
}
