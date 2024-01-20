using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Perl : BaseLanguage
{
	private Perl()
	{
	}

	public static Perl Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Perl";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Weak;
	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.ReferenceCounting;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Perl;

	public override Applications KnownForBuilding { get; } =
		Applications.Server | Applications.Web | Applications.Scripts | Applications.General;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented |
	                                               Paradigms.Imperative;

	public override double? TiobeRating { get; } = 0.55;
	public override int AppearanceYear { get; } = 1987;
}
