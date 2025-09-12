using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Xml;

public class NotesXmlSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("d121bcfc-64bf-4ec6-ae33-9b3d840b8ac5");

	public ILanguage Language => Languages.Xml.Instance;

	public string Filename => "notes.xml";

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
