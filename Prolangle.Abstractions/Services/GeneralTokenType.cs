namespace Prolangle.Abstractions.Services;

public enum GeneralTokenType
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
	Unknown,
}
