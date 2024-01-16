namespace Prolangle.Languages.Framework;

public interface ILanguage
{
	public Guid Id { get; }

	public string Name { get; }

	public TypeSystem Typing { get; }

	public bool Compiled { get; }

	public MemoryManagement MemoryManagement { get; }

	public SyntaxStyle SyntaxStyle { get; }

	public Applications KnownForBuilding { get; }

	public Paradigms Paradigms { get; }

	public double? TiobeRating { get; }

	public int AppearanceYear { get; }
}

public interface ILanguageSupportsSyntaxHighlighting : ILanguage
{
	/// <summary>
	/// The identifier, as listed at https://highlightjs.readthedocs.io/en/latest/supported-languages.html.
	/// </summary>
	public string HighlightJsIdentifier { get; }
}
