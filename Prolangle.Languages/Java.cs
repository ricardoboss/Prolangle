using Prolangle.Abstractions.Languages;

namespace Prolangle.Languages;

public class Java : BaseLanguage
{
	private Java()
	{
	}

	public static Java Instance { get; } = new();

	public override Guid Id { get; } = Guid.Parse("b7336e09-2a81-4b8a-ba13-688a1f691882");
	public override string Name { get; } = "Java";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Manifest;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.TracingGarbageCollection;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public override Applications KnownForBuilding { get; } = Applications.Web | Applications.Mobile | Applications.Desktop | Applications.Client | Applications.Server | Applications.General;
	public override Paradigms Paradigms { get; } = Paradigms.Generic | Paradigms.ObjectOriented | Paradigms.Functional | Paradigms.Imperative | Paradigms.Reflective | Paradigms.Concurrent;
	public override double? TiobeRating { get; } = 7.99;
	public override int AppearanceYear { get; } = 1995;
}
