namespace Prolangle.Abstractions.Services;

public enum TokenType
{
	None = 0,
	Whitespace,
	Keyword,
	Number,
	Text,
	Comment,
	Operator,
	Punctuation,
	Identifier,
	Other,
}
