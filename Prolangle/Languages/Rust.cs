using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Rust : BaseLanguage
{
	public override Guid Id { get; } = Guid.NewGuid();
	public override string Name { get; } = "Rust";
	public override TypeSystem Typing { get; } = TypeSystem.Inferred | TypeSystem.Nominal | TypeSystem.Static | TypeSystem.Strong;
	public override bool Compiled { get; } = true;
	public override MemoryManagement MemoryManagement { get; } = MemoryManagement.Manual;
	public override SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public override Applications KnownForBuilding { get; } = Applications.Server | Applications.General | Applications.System;

	public override Paradigms Paradigms { get; } = Paradigms.Concurrent | Paradigms.Functional | Paradigms.Generic |
	                                               Paradigms.Imperative | Paradigms.Structured;

	public override double? TiobeRating { get; } = 0.79;
	public override int AppearanceYear { get; } = 2015;
}
