using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Swift : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Swift";
	public override TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Inferred;
	public override bool Compiled { get; } = true;
	public override bool GarbageCollected { get; } = true;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;

	public override Applications KnownForBuilding { get; } = Applications.Apple | Applications.Mobile |
	                                                         Applications.Client | Applications.Desktop |
	                                                         Applications.System;

	public override Paradigms Paradigms { get; } = Paradigms.ObjectOriented | Paradigms.Functional |
	                                               Paradigms.Imperative | Paradigms.Declarative | Paradigms.Concurrent |
	                                               Paradigms.EventDriven | Paradigms.Reflective;

	public override double? TiobeRating { get; } = 0.82;
	public override int AppearanceYear { get; } = 2014;
}
