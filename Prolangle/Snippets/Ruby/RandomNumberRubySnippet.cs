using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Ruby;

public class RandomNumberRubySnippet : IAttributedCodeSnippet, ILicensedCodeSnippet
{
	public ILanguage Language => Languages.Ruby.Instance;
	public string Filename => "random_number.rb";
	public string Attribution => "https://en.wikipedia.org/w/index.php?title=Ruby_syntax&oldid=1267073271";
	public string License => "Creative Commons Attribution-ShareAlike License 4.0";

	public string SourceCode =>
		"""
		# Generate a random number and print whether it's even or odd.
		if rand(100).even?
		  puts "It's even"
		else
		  puts "It's odd"
		end
		""";
}
