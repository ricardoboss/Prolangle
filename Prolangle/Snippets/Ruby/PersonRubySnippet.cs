using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Ruby;

public class PersonRubySnippet : IAttributedCodeSnippet, ILicensedCodeSnippet
{
	public ILanguage Language => Languages.Ruby.Instance;
	public string Filename => "person.rb";
	public string Attribution => "https://en.wikipedia.org/w/index.php?title=Ruby_syntax&oldid=1267073271";
	public string License => "Creative Commons Attribution-ShareAlike License 4.0";

	public string SourceCode =>
		"""
		class Person
		  attr_reader :name, :age

		  def initialize(name, age)
		    @name, @age = name, age
		  end

		  def <=>(person) # the comparison operator for sorting
		    @age <=> person.age
		  end

		  def to_s
		    "#{@name} (#{@age})"
		  end
		end

		group = [
		  Person.new("Bob", 33),
		  Person.new("Chris", 16),
		  Person.new("Ash", 23)
		]

		puts group.sort.reverse
		""";
}
