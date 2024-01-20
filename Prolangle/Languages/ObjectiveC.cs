using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class ObjectiveC : BaseLanguage
{
	private ObjectiveC()
	{
	}

	public static ObjectiveC Instance { get; } = new();

	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Objective-C";
	public override TypeSystem Typing { get; } = TypeSystem.Dynamic | TypeSystem.Strong;
	public override bool Compiled { get; } = true;

	public override MemoryManagement MemoryManagement { get; } =
		MemoryManagement.ReferenceCounting;

	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.Smalltalk;

	public override Applications KnownForBuilding { get; } = Applications.Apple | Applications.Mobile |
	                                                         Applications.Client | Applications.Desktop |
	                                                         Applications.System;

	public override Paradigms Paradigms { get; } =
		Paradigms.ObjectOriented | Paradigms.EventDriven | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.43;
	public override int AppearanceYear { get; } = 1984;
}
