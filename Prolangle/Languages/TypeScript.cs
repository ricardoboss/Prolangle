using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class TypeScript : BaseLanguage
{
	private TypeScript()
	{
	}

	public static TypeScript Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name => "TypeScript";
	public override TypeSystem Typing => TypeSystem.Structural | TypeSystem.Strong | TypeSystem.Static;
	public override bool Compiled => true;
	public override MemoryManagement MemoryManagement => MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle => SyntaxStyle.C;

	public override Applications KnownForBuilding => Applications.Client | Applications.Server | Applications.Web;

	public override Paradigms Paradigms =>
		Paradigms.EventDriven | Paradigms.Functional | Paradigms.ObjectOriented | Paradigms.Generic;

	public override double? TiobeRating => 0.37;
	public override int AppearanceYear => 2012;
}
