using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using MatchType = Prolangle.Abstractions.Services.MatchType;

namespace Prolangle.Services;

[SuppressMessage("ReSharper", "ConvertIfStatementToReturnStatement")]
public class PropertiesLanguageComparer : ILanguageComparer
{
	private static TypeSystem TypeSystemOverlap(ILanguage left, ILanguage right)
	{
		return left.Typing & right.Typing;
	}

	private static Applications ApplicationsOverlap(ILanguage left, ILanguage right)
	{
		return left.KnownForBuilding & right.KnownForBuilding;
	}

	private static Paradigms ParadigmsOverlap(ILanguage left, ILanguage right)
	{
		return left.Paradigms & right.Paradigms;
	}

	private static ComparisonDirection TiobeRatingDirection(ILanguage left, ILanguage right)
	{
		if (left.TiobeRating is null && right.TiobeRating is null)
			return ComparisonDirection.Equal;

		if (right.TiobeRating is null) // left is non-null => higher
			return ComparisonDirection.Up;

		if (left.TiobeRating is null) // right is non-null => less
			return ComparisonDirection.Down;

		if (left.TiobeRating > right.TiobeRating)
			return ComparisonDirection.Up;

		if (left.TiobeRating < right.TiobeRating)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	private static ComparisonDirection AppearanceYearDirection(ILanguage left, ILanguage right)
	{
		if (left.AppearanceYear > right.AppearanceYear)
			return ComparisonDirection.Up;

		if (left.AppearanceYear < right.AppearanceYear)
			return ComparisonDirection.Down;

		return ComparisonDirection.Equal;
	}

	private static MatchType TypeSystemMatch(ILanguage left, ILanguage right)
	{
		var overlap = TypeSystemOverlap(left, right);

		if (overlap == TypeSystem.None)
			if (right.Typing == TypeSystem.None && left.Typing == TypeSystem.None)
				return MatchType.Exact; // both are none, therefore overlap is none
			else
				return MatchType.None;

		if (left.Typing == right.Typing)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	private static MatchType CompiledMatch(ILanguage left, ILanguage right)
	{
		if (right.Compiled == left.Compiled)
			return MatchType.Exact;

		return MatchType.None;
	}

	private static MatchType MemoryManagementMatch(ILanguage left, ILanguage right)
	{
		if (right.MemoryManagement == left.MemoryManagement)
			return MatchType.Exact;

		return MatchType.None;
	}

	private static MatchType SyntaxStyleMatch(ILanguage left, ILanguage right)
	{
		if (right.SyntaxStyle == left.SyntaxStyle)
			return MatchType.Exact;

		return MatchType.None;
	}

	private static MatchType ApplicationsMatch(ILanguage left, ILanguage right)
	{
		var overlap = ApplicationsOverlap(left, right);

		if (overlap == Applications.None)
			if (right.KnownForBuilding == Applications.None && left.KnownForBuilding == Applications.None)
				return MatchType.Exact; // both are none, therefore overlap is none
			else
				return MatchType.None;

		if (left.KnownForBuilding == right.KnownForBuilding)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	private static MatchType ParadigmsMatch(ILanguage left, ILanguage right)
	{
		var overlap = ParadigmsOverlap(left, right);

		if (overlap == Paradigms.None)
			return MatchType.None;

		if (left.Paradigms == right.Paradigms)
			return MatchType.Exact;

		return MatchType.Partial;
	}

	private static MatchType TiobeRatingMatch(ILanguage left, ILanguage right)
	{
		if (right.TiobeRating is null && left.TiobeRating is null)
			return MatchType.Exact;

		if (right.TiobeRating is null)
			return MatchType.None;

		if (left.TiobeRating is null)
			return MatchType.None;

		// floating point comparison
		if (Math.Abs(right.TiobeRating.Value - left.TiobeRating.Value) <= double.Epsilon)
			return MatchType.Exact;

		return MatchType.None;
	}

	private static MatchType AppearanceYearMatch(ILanguage left, ILanguage right)
	{
		if (right.AppearanceYear == left.AppearanceYear)
			return MatchType.Exact;

		return MatchType.None;
	}

	public LanguageComparison Compare(ILanguage left, ILanguage right)
	{
		return new()
		{
			TypeSystem = TypeSystemOverlap(left, right),
			TypeSystemMatch = TypeSystemMatch(left, right),
			CompiledMatch = CompiledMatch(left, right),
			MemoryManagementMatch = MemoryManagementMatch(left, right),
			SyntaxStyleMatch = SyntaxStyleMatch(left, right),
			Applications = ApplicationsOverlap(left, right),
			ApplicationsMatch = ApplicationsMatch(left, right),
			Paradigms = ParadigmsOverlap(left, right),
			ParadigmsMatch = ParadigmsMatch(left, right),
			TiobeRatingMatch = TiobeRatingMatch(left, right),
			TiobeRatingDirection = TiobeRatingDirection(left, right),
			AppearanceYearMatch = AppearanceYearMatch(left, right),
			AppearanceYearDirection = AppearanceYearDirection(left, right),
		};
	}
}

public static class PropertiesLanguageComparerServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddPropertiesLanguageComparer(this IServiceCollection services)
	{
		services.AddSingleton<ILanguageComparer, PropertiesLanguageComparer>();

		return services;
	}
}
