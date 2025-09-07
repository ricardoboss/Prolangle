using Blism;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;
using Prolangle.Tokenizers;

namespace Prolangle.Snippets.Assembly;

public class BlinkAssemblySnippet : IAttributedCodeSnippet, ICustomTokenizerSnippet
{
	public Guid Id { get; } = Guid.Parse("23f77a04-7fec-45db-b806-ed0d1d8dad3e");

	public ILanguage Language => Languages.Assembly.Instance;

	public ITokenizer<GeneralTokenType> Tokenizer => Asm6502Tokenizer.Instance;

	public string Filename => "blink.s";

	public string SourceCode => """
	                              .org $8000

	                            reset:
	                              lda #$ff
	                              sta $6002

	                              lda #$50
	                              sta $6000

	                            loop:
	                              ror
	                              sta $6000

	                              jmp loop

	                              .org $fffc
	                              .word reset
	                              .word $0000
	                            """;

	public string Attribution => "https://eater.net/6502";
}
