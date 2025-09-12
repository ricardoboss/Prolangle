using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Pascal : BaseLanguage
{
	private Pascal()
	{
	}

	public static Pascal Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("281a520a-7a71-405c-8336-8a0f0850b1d4");
	public override string Name { get; } = "Pascal";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Pascal;
	public override Applications KnownForBuilding { get; } = Applications.Education | Applications.Desktop;
	public override Paradigms Paradigms { get; } = Paradigms.Imperative | Paradigms.Structured | Paradigms.Procedural;
	public override double? TiobeRating { get; } = 0.92;
	public override int AppearanceYear { get; } = 1970;
}
