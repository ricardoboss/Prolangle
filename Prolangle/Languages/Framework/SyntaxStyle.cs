using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum SyntaxStyle
{
	None,
	Other,

	Assembly,

	[Description("The C syntax style is perhaps most recognizable by blocks " +
	             "being delineated in curly braces { }, and by statements " +
	             "typically ending with a semicolon ;.")]
	C,

	[Description("In the indendation syntax style, the indentation (the " +
	             "spacing to the very left of a line) is semantically " +
	             "important. It is used to delineate blocks of code.")]
	Indentation,
	Lisp,
	Pascal,
	Perl,

	[Description("In the XML or SGML syntax style, tags use angular brackets " +
	             "< >, and can be nested, to form a document tree.")]
	[Display(Name = "XML")]
	Xml,
}
