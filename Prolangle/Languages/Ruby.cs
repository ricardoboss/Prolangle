using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Ruby : BaseLanguage
{
	private Ruby()
	{
	}

	public static Ruby Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Ruby";
	public override TypeSystem Typing { get; } = TypeSystem.Duck | TypeSystem.Dynamic | TypeSystem.Strong;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Perl;

	public override Applications KnownForBuilding { get; } = Applications.Configuration |
	                                                         Applications.Server | Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented | Paradigms.Functional |
	                                               Paradigms.Imperative | Paradigms.Structured | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.77;
	public override int AppearanceYear { get; } = 1995;
}
