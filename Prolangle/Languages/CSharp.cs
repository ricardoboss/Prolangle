using Prolangle.Languages.Framework;

namespace Prolangle.Languages;

public class CSharp : ILanguage
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; } = "C#";
	public TypeSystem Typing { get; } = TypeSystem.Static | TypeSystem.Strong | TypeSystem.Dynamic | TypeSystem.Safe | TypeSystem.Nominal | TypeSystem.Inferred;
	public bool Compiled { get; } = true;
	public bool GarbageCollected { get; } = true;
	public SyntaxStyle SyntaxStyle { get; } = SyntaxStyle.C;
	public Applications KnownForBuilding { get; } = Applications.Microsoft | Applications.Web | Applications.Desktop | Applications.Client | Applications.Server | Applications.General;
	public Paradigms Paradigms { get; } = Paradigms.ObjectOriented | Paradigms.Functional | Paradigms.Structured | Paradigms.Imperative | Paradigms.Generic | Paradigms.Reflective | Paradigms.EventDriven | Paradigms.TaskDriven | Paradigms.Concurrent;
	public double? TiobeRating { get; } = 7.3;
	public int AppearanceYear { get; } = 2000;
}
