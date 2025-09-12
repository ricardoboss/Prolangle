using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Xml;

public class BookstoreXmlSnippet : IAttributedCodeSnippet
{
	public Guid Id { get; } = Guid.Parse("fb22a666-9139-4017-b483-b1923e46942b");

	public ILanguage Language => Languages.Xml.Instance;

	public string Filename => "bookstore.xml";

	public string SourceCode => """
	                            <?xml version="1.0" encoding="UTF-8"?>
	                            <bookstore>
	                              <book category="cooking">
	                                <title lang="en">Everyday Italian</title>
	                                <author>Giada De Laurentiis</author>
	                                <year>2005</year>
	                                <price>30.00</price>
	                              </book>
	                              <book category="children">
	                                <title lang="en">Harry Potter</title>
	                                <author>J K. Rowling</author>
	                                <year>2005</year>
	                                <price>29.99</price>
	                              </book>
	                              <book category="web">
	                                <title lang="en">Learning XML</title>
	                                <author>Erik T. Ray</author>
	                                <year>2003</year>
	                                <price>39.95</price>
	                              </book>
	                            </bookstore>
	                            """;

	public string Attribution => "https://www.w3schools.com/xml/xml_tree.asp";
}
