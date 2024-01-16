using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Css : BaseLanguage
{
	private Css()
	{
	}

	public static Css Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "CSS";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;
	public override Applications KnownForBuilding { get; } = Applications.Web;
	public override Paradigms Paradigms { get; } = Paradigms.Declarative;
	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1996;
}
