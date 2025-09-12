using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.GraphQl;

public class QueryGraphQlSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("10d10fac-7cbd-447e-90dd-b0ef31124bb3");

	public ILanguage Language => Languages.GraphQl.Instance;

	public string Filename => "ten-dollar-items.gql";

	public string SourceCode =>
		"""
		query TenDollarItems {
		  items(where: { value: {_eq: 10}}) {
		    name
		    count
		    value
		  }
		}
		""";

	public string Attribution => "https://hasura.io/blog/graphql-examples";
}
