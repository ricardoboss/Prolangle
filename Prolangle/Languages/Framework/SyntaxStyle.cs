using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum SyntaxStyle
{
	None,
	Other,

	Assembly,
	C,
	Indentation,
	Lisp,
	Pascal,
	Perl,
	[Display(Name = "XML")]
	Xml,
}
