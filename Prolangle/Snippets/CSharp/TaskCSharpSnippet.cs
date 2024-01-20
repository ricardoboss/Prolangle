using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.CSharp;

public class TaskCSharpSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.CSharp.Instance;

	public string Filename => "AsyncTaskExample.cs";

	public string SourceCode =>
		"""
		using System;
		using System.Threading.Tasks;

		namespace AsyncTaskExample
		{
		    class Program
		    {
		        static async Task Main(string[] args)
		        {
		            Console.WriteLine("Starting Task");

		            Task<int> task = DoWorkAsync();

		            Console.WriteLine("Continuing with other work");

		            int result = await task;

		            Console.WriteLine($"Task complete with result: {result}");
		        }

		        static async Task<int> DoWorkAsync()
		        {
		            Console.WriteLine("Task started");

		            // Simulate work
		            await Task.Delay(1000);

		            Console.WriteLine("Task complete");
		            return 1;
		        }
		    }
		}
		""";
}
