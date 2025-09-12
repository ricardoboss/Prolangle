using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Logo : BaseLanguage
{
	private Logo()
	{
	}

	public static Logo Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("b96e2784-980f-44cd-b3df-c7f64db5491a");
	public override string Name { get; } = "Logo";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic;
	public override bool Compiled { get; }
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.None;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Education | Applications.Fun;

	public override Paradigms Paradigms { get; } = Paradigms.Imperative;

	public override double? TiobeRating { get; } = 0.14;
	public override int AppearanceYear { get; } = 1967;
}
