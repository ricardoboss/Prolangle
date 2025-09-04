using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.CSharp;

public class SimpleCSharpSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("314b55d7-55d1-4a33-82f0-c8131f378047");

	public ILanguage Language => Languages.CSharp.Instance;

	public string Filename => "Program.cs";

	public string SourceCode =>
		"""
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;

		namespace CSharpTutorials
		{
		    class Program
		    {
		        static void Main(string[] args)
		        {
		            string message = "Hello World!!";

		            Console.WriteLine(message);
		        }
		    }
		}
		""";
}
