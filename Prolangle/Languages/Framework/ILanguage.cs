namespace Prolangle.Languages.Framework;

public interface ILanguage
{
	public Guid Id { get; }

	public string Name { get; }

	public TypeSystem Typing { get; }

	public bool Compiled { get; }

	public bool GarbageCollected { get; }

	public SyntaxStyle SyntaxStyle { get; }

	public Applications KnownForBuilding { get; }

	public Paradigms Paradigms { get; }

	public double? TiobeRating { get; }

	public int AppearanceYear { get; }
}
