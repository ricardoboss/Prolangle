using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Ruby;

public class ReadLinesRubySnippet : IAttributedCodeSnippet, ILicensedCodeSnippet
{
	public ILanguage Language => Languages.Ruby.Instance;
	public string Filename => "read_lines.rb";
	public string Attribution => "https://en.wikipedia.org/w/index.php?title=Ruby_syntax&oldid=1267073271";
	public string License => "Creative Commons Attribution-ShareAlike License 4.0";

	public string SourceCode =>
		"""
		File.readlines('file.txt').each do |line|
		  puts line
		end
		""";
}
