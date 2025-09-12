using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Sql;

public class SimpleSqlSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("ed83afe1-511c-41e4-b7d4-6b5470c6c07d");

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
