using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.GraphQl;

public class SpaceXLaunchesGraphQlSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("f130727d-b6d3-439d-a1cf-a8e665bd1a76");

	public ILanguage Language => Languages.GraphQl.Instance;

	public string Filename => "space-x-launches.gql";

	public string SourceCode =>
		"""
		{
		  launchesPast(limit: 10) {
		    mission_name
		    launch_date_local
		    launch_site {
		      site_name_long
		    }
		    links {
		      article_link
		      video_link
		    }
		    rocket {
		      rocket_name
		    }
		  }
		}
		""";

	public string Attribution =>
		"https://www.apollographql.com/blog/8-free-to-use-graphql-apis-for-your-projects-and-demos";
}
