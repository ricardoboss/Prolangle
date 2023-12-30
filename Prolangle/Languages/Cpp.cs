using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Cpp : ILanguage
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; } = "C++";
	public TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Nominal | TypeSystem.Inferred;
	public bool Compiled { get; } = true;
	public bool GarbageCollected { get; } = false;
	public SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public Applications KnownForBuilding { get; } = Applications.System | Applications.Games | Applications.General;
	public Paradigms Paradigms { get; } = Paradigms.Procedural | Paradigms.Imperative | Paradigms.Functional | Paradigms.ObjectOriented | Paradigms.Generic;
	public double? TiobeRating { get; } = 10.01;
	public int AppearanceYear { get; } = 1985;
}
