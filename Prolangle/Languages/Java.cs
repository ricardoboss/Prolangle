using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class Java : ILanguage
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; } = "Java";
	public TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Manifest;
	public bool Compiled { get; } = true;
	public bool GarbageCollected { get; } = true;
	public SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public Applications KnownForBuilding { get; } = Applications.Web | Applications.Mobile | Applications.Desktop | Applications.Client | Applications.Server | Applications.General;
	public Paradigms Paradigms { get; } = Paradigms.Generic | Paradigms.ObjectOriented | Paradigms.Functional | Paradigms.Imperative | Paradigms.Reflective | Paradigms.Concurrent;
	public double? TiobeRating { get; } = 7.99;
	public int AppearanceYear { get; } = 1995;
}
