using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum SyntaxStyle
{
	None,
	Other,

	[Description("In the assembly syntax style, each line starts with a short " +
	             "command string, optionally followed by one or more parameters.")]
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

	[Description("In Smalltalk syntax, you start with the receiver of a " +
	             "message (an object), then continue with the message to " +
	             "send to it.")]
	Smalltalk,

	[Description("In the XML or SGML syntax style, tags use angular brackets " +
	             "< >, and can be nested, to form a document tree.")]
	[Display(Name = "XML")]
	Xml,

	[Description("In the visual syntax style, code is represented visually, " +
	             "often as blocks that can be dragged and dropped.")]
	Visual
}
