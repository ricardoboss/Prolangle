using Prolangle.Languages.Framework;
using Prolangle.Models;
using MatchType = Prolangle.Models.MatchType;

namespace Prolangle.Services;

public class MetadatumComparisonService(ILanguage targetLanguage)
{
	public TypeSystem TypingOverlap(ILanguage language)
	{
		return language.Typing & targetLanguage.Typing;
	}

	public Applications ApplicationsOverlap(ILanguage language)
	{
		return language.KnownForBuilding & targetLanguage.KnownForBuilding;
	}

	public Paradigms ParadigmsOverlap(ILanguage language)
	{
		return language.Paradigms & targetLanguage.Paradigms;
	}

	public ComparisonDirection TiobeRatingDirection(ILanguage language)
	{
		if (language.TiobeRating is null && targetLanguage.TiobeRating is null)
			return ComparisonDirection.Equal;

		if (language.TiobeRating is null)
			return ComparisonDirection.Up;

		if (targetLanguage.TiobeRating is null)
			return ComparisonDirection.Down;

		if (language.TiobeRating < targetLanguage.TiobeRating)
			return ComparisonDirection.Up;

		if (language.TiobeRating > targetLanguage.TiobeRating)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	public ComparisonDirection AppearanceYearDirection(ILanguage language)
	{
		if (language.AppearanceYear < targetLanguage.AppearanceYear)
			return ComparisonDirection.Up;

		if (language.AppearanceYear > targetLanguage.AppearanceYear)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	public MatchType TypingMatch(ILanguage language)
	{
		TypeSystem overlap = TypingOverlap(language);

		if (overlap == TypeSystem.None)
			return language.Typing == TypeSystem.None && targetLanguage.Typing == TypeSystem.None ? MatchType.Exact : MatchType.None;

		if (targetLanguage.Typing == language.Typing)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType CompiledMatch(ILanguage language)
	{
		if (language.Compiled == targetLanguage.Compiled)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType GarbageCollectedMatch(ILanguage language)
	{
		if (language.MemoryManagement == targetLanguage.MemoryManagement)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType SyntaxStyleMatch(ILanguage language)
	{
		if (language.SyntaxStyle == targetLanguage.SyntaxStyle)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType ApplicationsMatch(ILanguage language)
	{
		var overlap = ApplicationsOverlap(language);

		if (overlap == Applications.None)
			return MatchType.None;

		if (targetLanguage.KnownForBuilding == language.KnownForBuilding)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType ParadigmsMatch(ILanguage language)
	{
		var overlap = ParadigmsOverlap(language);

		if (overlap == Paradigms.None)
			return MatchType.None;

		if (targetLanguage.Paradigms == language.Paradigms)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	public MatchType TiobeRatingMatch(ILanguage language)
	{
		if (language.TiobeRating is null && targetLanguage.TiobeRating is null)
			return MatchType.Exact;

		if (language.TiobeRating is null)
			return MatchType.None;

		if (targetLanguage.TiobeRating is null)
			return MatchType.None;

		// floating point comparison
		if (Math.Abs(language.TiobeRating.Value - targetLanguage.TiobeRating.Value) <= double.Epsilon)
			return MatchType.Exact;

		return MatchType.None;
	}

	public MatchType AppearanceYearMatch(ILanguage language)
	{
		if (language.AppearanceYear == targetLanguage.AppearanceYear)
			return MatchType.Exact;

		return MatchType.None;
	}
}
