namespace Prolangle.Abstractions.Services;

/// <param name="Visibility">Whether or not this token is concealed.</param>
public record ConcealableCodeToken(
	int StartIndex,
	string Text,
	TokenType Type,
	CodeTokenVisibility Visibility = CodeTokenVisibility.Visible
) : CodeToken(StartIndex, Text, Type)
{
	public static ConcealableCodeToken FromCodeToken(CodeToken token,
		CodeTokenVisibility visibility = CodeTokenVisibility.Visible) =>
		new(token.StartIndex, token.Text, token.Type, visibility);
}
