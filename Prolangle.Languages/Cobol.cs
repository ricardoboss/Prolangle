using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Cobol : BaseLanguage
{
	private Cobol()
	{
	}

	public static Cobol Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("315f183d-b753-4def-a8bf-df8b21fa8694");
	public override string Name { get; } = "COBOL";

	public override TypeSystem Typing { get; } = TypeSystem.Static |
	                                             TypeSystem.Weak |
	                                             TypeSystem.Manifest |
	                                             TypeSystem.Nominal;

	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Other;

	public override Applications KnownForBuilding { get; } = Applications.Server | Applications.General;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Procedural;
	public override double? TiobeRating { get; } = 1.09;
	public override int AppearanceYear { get; } = 1959;
}
