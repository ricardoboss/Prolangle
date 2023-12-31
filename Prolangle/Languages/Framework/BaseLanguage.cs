namespace Prolangle.Languages.Framework;

public abstract class BaseLanguage : ILanguage
{
	public abstract Guid Id { get; }
	public abstract string Name { get; }
	public abstract TypeSystem Typing { get; }
	public abstract bool Compiled { get; }
	public abstract bool GarbageCollected { get; }
	public abstract SyntaxStyle SyntaxStyle { get; }
	public abstract Applications KnownForBuilding { get; }
	public abstract Paradigms Paradigms { get; }
	public abstract double? TiobeRating { get; }
	public abstract int AppearanceYear { get; }

	public override string ToString()
	{
		return $"Name = {Name}; Typing = {Typing}; Compiled = {Compiled}; GarbageCollected = {GarbageCollected}; SyntaxStyle = {SyntaxStyle}; KnownForBuilding = {KnownForBuilding}; Paradigms = {Paradigms}; TiobeRating = {TiobeRating}; AppearanceYear = {AppearanceYear}";
	}
}
