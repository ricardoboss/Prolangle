using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Xml : BaseLanguage
{
	private Xml()
	{
	}

	public static Xml Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "XML";
	public override TypeSystem Typing { get; } = TypeSystem.None;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Xml;

	public override Applications KnownForBuilding { get; } = Applications.Client | Applications.Documents |
								 Applications.Server | Applications.Scripts |
								 Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;
	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 1996;
}
