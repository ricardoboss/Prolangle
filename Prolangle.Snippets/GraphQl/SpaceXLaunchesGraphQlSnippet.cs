using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.GraphQl;

public class SpaceXLaunchesGraphQlSnippet : IAttributedCodeSnippet
{
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
