namespace Prolangle.Abstractions.Services;

public class LanguageNotFoundException : Exception
{
	public LanguageNotFoundException()
	{
	}

	public LanguageNotFoundException(string message) : base(message)
	{
	}

	public LanguageNotFoundException(string message, Exception inner) : base(message, inner)
	{
	}

	public static LanguageNotFoundException ById(Guid id) => new($"No language with ID '{id}' found");
}
