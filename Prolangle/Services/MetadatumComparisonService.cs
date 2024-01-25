using Prolangle.Languages.Framework;
using Prolangle.Models;
using MatchType = Prolangle.Models.MatchType;

namespace Prolangle.Services;

public class MetadatumComparisonService(ILanguage targetLanguage)
{
	public TypeSystem TypingOverlap(ILanguage otherLanguage)
	{
		return otherLanguage.Typing & targetLanguage.Typing;
	}

	public Applications ApplicationsOverlap(ILanguage otherLanguage)
	{
		return otherLanguage.KnownForBuilding & targetLanguage.KnownForBuilding;
	}

	public Paradigms ParadigmsOverlap(ILanguage otherLanguage)
	{
		return otherLanguage.Paradigms & targetLanguage.Paradigms;
	}

	public ComparisonDirection TiobeRatingDirection(ILanguage otherLanguage)
	{
		if (otherLanguage.TiobeRating is null && targetLanguage.TiobeRating is null)
			return ComparisonDirection.Equal;

		if (otherLanguage.TiobeRating is null)
			return ComparisonDirection.Up;

		if (targetLanguage.TiobeRating is null)
			return ComparisonDirection.Down;

		if (otherLanguage.TiobeRating < targetLanguage.TiobeRating)
			return ComparisonDirection.Up;

		if (otherLanguage.TiobeRating > targetLanguage.TiobeRating)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	public ComparisonDirection AppearanceYearDirection(ILanguage otherLanguage)
	{
		if (otherLanguage.AppearanceYear < targetLanguage.AppearanceYear)
			return ComparisonDirection.Up;

		if (otherLanguage.AppearanceYear > targetLanguage.AppearanceYear)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	public MatchType TypingMatch(ILanguage otherLanguage)
	{
		TypeSystem overlap = TypingOverlap(otherLanguage);

		if (overlap == TypeSystem.None)
			return otherLanguage.Typing == TypeSystem.None && targetLanguage.Typing == TypeSystem.None ? MatchType.Exact : MatchType.None;

		if (targetLanguage.Typing == otherLanguage.Typing)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType CompiledMatch(ILanguage otherLanguage)
	{
		if (otherLanguage.Compiled == targetLanguage.Compiled)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType GarbageCollectedMatch(ILanguage otherLanguage)
	{
		if (otherLanguage.MemoryManagement == targetLanguage.MemoryManagement)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType SyntaxStyleMatch(ILanguage otherLanguage)
	{
		if (otherLanguage.SyntaxStyle == targetLanguage.SyntaxStyle)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType ApplicationsMatch(ILanguage otherLanguage)
	{
		var overlap = ApplicationsOverlap(otherLanguage);

		if (overlap == Applications.None)
			return otherLanguage.KnownForBuilding == Applications.None && targetLanguage.KnownForBuilding == Applications.None ? MatchType.Exact : MatchType.None;

		if (targetLanguage.KnownForBuilding == otherLanguage.KnownForBuilding)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType ParadigmsMatch(ILanguage otherLanguage)
	{
		var overlap = ParadigmsOverlap(otherLanguage);

		if (overlap == Paradigms.None)
			return MatchType.None;

		if (targetLanguage.Paradigms == otherLanguage.Paradigms)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType TiobeRatingMatch(ILanguage otherLanguage)
	{
		if (otherLanguage.TiobeRating is null && targetLanguage.TiobeRating is null)
			return MatchType.Exact;

		if (otherLanguage.TiobeRating is null)
			return MatchType.None;

		if (targetLanguage.TiobeRating is null)
			return MatchType.None;

		// floating point comparison
		if (Math.Abs(otherLanguage.TiobeRating.Value - targetLanguage.TiobeRating.Value) <= double.Epsilon)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType AppearanceYearMatch(ILanguage otherLanguage)
	{
		if (otherLanguage.AppearanceYear == targetLanguage.AppearanceYear)
			return MatchType.Exact;

		return MatchType.None;
	}
}
