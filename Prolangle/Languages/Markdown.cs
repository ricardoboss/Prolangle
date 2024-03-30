using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Markdown : BaseLanguage
{
	private Markdown()
	{
	}

	public static Markdown Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Markdown";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Documents |
	                                                         Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;

	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 2004;
}
