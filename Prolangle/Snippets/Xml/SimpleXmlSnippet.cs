using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Xml;

public class SimpleXmlSnippet : IAttributedCodeSnippet
{
	public ILanguage Language => Languages.Xml.Instance;

	public string Filename => "Snippet.xml";

	public string SourceCode =>
		"""
		<?xml version="1.0" encoding="UTF-8"?>
		<notes>
			<note>
				<to>Tove</to>
				<from>Jani</from>
				<heading>Reminder</heading>
				<body>Don't forget me this weekend!</body>
			</note>
			<note>
				<to>Jani</to>
				<from>Tove</from>
				<heading>Re: Reminder</heading>
				<body>I will not</body>
			</note>
		</notes>
		""";

	public string Attribution =>
		"https://docs.actian.com/integrationmanager/1.6/index.html#page/User/Example_Messages.htm";
}
