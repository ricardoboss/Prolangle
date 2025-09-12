using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Python : BaseLanguage
{
	private Python()
	{
	}

	public static Python Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("e7b27431-f92d-4f4b-b30a-db85805c0344");
	public override string Name { get; } = "Python";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Strong | TypeSystem.Duck;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.ReferenceCounting;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Indentation;

	public override Applications KnownForBuilding { get; } = Applications.General | Applications.Web | Applications.Ai |
	                                                         Applications.Science | Applications.Education |
	                                                         Applications.Scripts;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented | Paradigms.Procedural |
	                                               Paradigms.Imperative | Paradigms.Functional | Paradigms.Structured |
	                                               Paradigms.Reflective;

	public override double? TiobeRating { get; } = 13.86;
	public override int AppearanceYear { get; } = 1991;
}
