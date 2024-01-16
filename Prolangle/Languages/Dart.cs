using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Dart : BaseLanguage
{
	private Dart()
	{
	}

	public static Dart Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Dart";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Inferred;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } = Applications.Mobile | Applications.Web;

	public override Paradigms Paradigms { get; } = Paradigms.Functional | Paradigms.Imperative |
	                                               Paradigms.ObjectOriented | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.47;
	public override int AppearanceYear { get; } = 2011;
}
