using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Smalltalk;

/// <remarks>
/// From https://www.quickread.in/smalltalk-programming-a-comprehensive-guide/
/// </remarks>
public class BankingSmalltalkSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Smalltalk.Instance;

	public string Filename => "banking.st";

	public string SourceCode =>
		"""
		Object subclass: #BankAccount
		    instanceVariableNames: 'owner balance'
		    classVariableNames: ''
		    poolDictionaries: ''
		    category: 'Banking'

		BankAccount>>initialize
		    balance := 0.

		BankAccount>>deposit: amount
		    balance := balance + amount.

		BankAccount>>withdraw: amount
		    balance := balance - amount.

		BankAccount>>displayBalance
		    Transcript show: 'Current balance: ', balance asString; cr.

		| account |
		account := BankAccount new.
		account initialize.
		account deposit: 1000.
		account displayBalance.
		account withdraw: 500.
		account displayBalance.
		""";
}
