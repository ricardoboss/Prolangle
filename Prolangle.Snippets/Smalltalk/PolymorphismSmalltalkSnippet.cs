using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Smalltalk;

/// <remarks>
/// From https://www.quickread.in/smalltalk-programming-a-comprehensive-guide/
/// </remarks>
public class PolymorphismSmalltalkSnippet : ICodeSnippet
{
	public ILanguage Language => Languages.Smalltalk.Instance;

	public string Filename => "shapes.st";

	public string SourceCode =>
		"""
		Object subclass: Shape [
		    area [
		        "Abstract method to be overridden in subclasses"
		    ]
		]

		Shape subclass: Rectangle [
		    | width height |

		    initialize: w height: h [
		        width := w.
		        height := h.
		    ]

		    area [
		        ^ width * height.
		    ]
		]

		Shape subclass: Circle [
		    | radius |

		    initialize: r [
		        radius := r.
		    ]

		    area [
		        ^ 3.14 * radius * radius.
		    ]
		]
		""";
}
