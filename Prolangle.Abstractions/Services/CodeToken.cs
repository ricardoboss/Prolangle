namespace Prolangle.Abstractions.Services;

/// <summary>
/// Represents a token in some source code.
/// </summary>
/// <param name="StartIndex">The start index of this token (inclusive) in the source code.</param>
/// <param name="Text">The display text of this token.</param>
/// <param name="Type">The meaning of the token.</param>
public record CodeToken(int StartIndex, string Text, TokenType Type);
