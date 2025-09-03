using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class GraphQl : BaseLanguage
{
	private GraphQl()
	{
	}

	public static GraphQl Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("3ba54e43-cacf-4885-b5a7-ba1ebe805270");
	public override string Name { get; } = "GraphQL";

	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Strong;

	public override bool Compiled { get; } = false;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } =
		Applications.Web | Applications.Client;

	public override Paradigms Paradigms { get; } = Paradigms.Declarative;

	public override double? TiobeRating { get; } = null;
	public override int AppearanceYear { get; } = 2015;
}
