namespace Prolangle.Abstractions.Services;

public class SnippetNotFoundException : Exception
{
	public SnippetNotFoundException()
	{
	}

	public SnippetNotFoundException(string message) : base(message)
	{
	}

	public SnippetNotFoundException(string message, Exception inner) : base(message, inner)
	{
	}

	public static SnippetNotFoundException ById(Guid id) => new($"No snippet with ID '{id}' found");
}
