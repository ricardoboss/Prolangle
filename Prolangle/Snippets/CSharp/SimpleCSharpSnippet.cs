namespace Prolangle.Snippets.CSharp;

public class SimpleCSharpSnippet : ICodeSnippet
{
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
