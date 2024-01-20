using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.SQL;

public class SimpleSqlSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Sql.Instance;

	public string Filename => "Query.sql";

	public string SourceCode =>
		"""
		SELECT id, name, age, address
		FROM users
		WHERE id = 1 AND name <> 'John Doe'
		ORDER BY id DESC
		""";
}
