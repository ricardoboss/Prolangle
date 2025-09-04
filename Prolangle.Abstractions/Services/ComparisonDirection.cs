namespace Prolangle.Abstractions.Services;

/// <summary>
/// A comparison direction, telling how one value needs to adjust to get to the other one.
/// </summary>
public enum ComparisonDirection
{
	/// <summary>
	/// Both values are equal or equivalent.
	/// </summary>
	Equal,

	/// <summary>
	/// Left is "more"/"higher" than right.
	/// </summary>
	Up,

	/// <summary>
	/// Left is "less"/"lower" than right.
	/// </summary>
	Down,
}
