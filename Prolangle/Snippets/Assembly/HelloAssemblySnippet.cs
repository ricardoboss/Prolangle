using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Assembly;

public class HelloAssemblySnippet : IAttributedCodeSnippet, ILicensedCodeSnippet
{
	public ILanguage Language => Languages.Assembly.Instance;

	public string Filename => "hello.asm";

	public string SourceCode =>
		"""
		          global    _start

		          section   .text
		_start:   mov       rax, 1                  ; system call for write
		          mov       rdi, 1                  ; file handle 1 is stdout
		          mov       rsi, message            ; address of string to output
		          mov       rdx, 13                 ; number of bytes
		          syscall                           ; invoke operating system to do the write
		          mov       rax, 60                 ; system call for exit
		          xor       rdi, rdi                ; exit code 0
		          syscall                           ; invoke operating system to exit

		          section   .data
		message:  db        "Hello, World", 10      ; note the newline at the end
		""";

	public string Attribution => "https://stackoverflow.com/q/61533696";
	public string License => "CC BY-SA 4.0";
}
