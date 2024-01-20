using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Php : BaseLanguage
{
	private Php()
	{
	}

	public static Php Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "PHP";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.ReferenceCounting;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } =
		Applications.Server | Applications.Web | Applications.Scripts;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Functional |
	                                               Paradigms.ObjectOriented | Paradigms.Procedural |
	                                               Paradigms.Reflective;

	public override double? TiobeRating { get; } = 2.01;
	public override int AppearanceYear { get; } = 1995;
}
