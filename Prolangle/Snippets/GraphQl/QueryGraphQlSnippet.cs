using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.GraphQl;

public class QueryGraphQlSnippet : IAttributedCodeSnippet
{
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
