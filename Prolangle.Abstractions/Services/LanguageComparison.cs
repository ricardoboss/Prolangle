using Prolangle.Abstractions.Languages;

namespace Prolangle.Abstractions.Services;

public class LanguageComparison
{
	public required TypeSystem TypeSystem { get; init; }

	public required MatchType TypeSystemMatch { get; init; }

	public required MatchType CompiledMatch { get; init; }

	public required MatchType MemoryManagementMatch { get; init; }

	public required MatchType SyntaxStyleMatch { get; init; }

	public required Applications Applications { get; init; }

	public required MatchType ApplicationsMatch { get; init; }

	public required Paradigms Paradigms { get; init; }

	public required MatchType ParadigmsMatch { get; init; }

	public required MatchType TiobeRatingMatch { get; init; }

	public required ComparisonDirection TiobeRatingDirection { get; init; }

	public required MatchType AppearanceYearMatch { get; init; }

	public required ComparisonDirection AppearanceYearDirection { get; init; }

	public bool AreEqual => TypeSystemMatch == MatchType.Exact && CompiledMatch == MatchType.Exact &&
	                        MemoryManagementMatch == MatchType.Exact && SyntaxStyleMatch == MatchType.Exact &&
	                        ApplicationsMatch == MatchType.Exact && ParadigmsMatch == MatchType.Exact &&
	                        TiobeRatingMatch == MatchType.Exact && AppearanceYearMatch == MatchType.Exact;
}
