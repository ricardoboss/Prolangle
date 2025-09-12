namespace Prolangle.Abstractions.Languages;

/// <summary>
/// Represents a programming language.
/// </summary>
public interface ILanguage
{
	/// <summary>
	/// A globally unique, never changing ID for this language.
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// The name of this programming language.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// The type systems that apply to this language.
	/// </summary>
	public TypeSystem Typing { get; }

	/// <summary>
	/// Whether or not this is a compiled language.
	/// </summary>
	public bool Compiled { get; }

	/// <summary>
	/// What kind of memory management applies for this language.
	/// </summary>
	public MemoryManagement MemoryManagement { get; }

	/// <summary>
	/// The syntax style for this language.
	/// </summary>
	public SyntaxStyle SyntaxStyle { get; }

	/// <summary>
	/// The usual applications for this programming language.
	/// </summary>
	public Applications KnownForBuilding { get; }

	/// <summary>
	/// The paradigms this language fits into.
	/// </summary>
	public Paradigms Paradigms { get; }

	/// <summary>
	/// If applicable, the TIOBE rating for this language (year 2023).
	/// </summary>
	public double? TiobeRating { get; }

	/// <summary>
	/// The year this language first appeared.
	/// </summary>
	public int AppearanceYear { get; }
}
