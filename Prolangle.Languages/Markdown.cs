using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Markdown : BaseLanguage
{
	private Markdown()
	{
	}

	public static Markdown Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("3aa2a78f-ad7e-490a-ad55-df84966c61de");
	public override string Name { get; } = "Markdown";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Documents |
	                                                         Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;

	public override double? TiobeRating { get; }
	public override int AppearanceYear { get; } = 2004;
}
