using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

[Flags]
public enum Paradigms
{
	None = 0,

	[Display(Name = "Object-oriented")]
	ObjectOriented = 1 << 0,

	Functional = 1 << 1,
	Generic = 1 << 2,
	Imperative = 1 << 3,
	Structured = 1 << 4,
	Procedural = 1 << 5,
	Declarative = 1 << 6,

	[Display(Name = "Event-driven")]
	EventDriven = 1 << 7,

	Reflective = 1 << 8,

	[Display(Name = "Task-driven")]
	TaskDriven = 1 << 9,

	Concurrent = 1 << 10,

	[Display(Name = "Natural language")]
	NaturalLanguage = 1 << 11,

	[Display(Name = "Object-based")]
	[Description("An object-based language is similar to an object-oriented " +
	             "language, but does not support the full feature set " +
	             "generally expected from OOP. For example, it may lack " +
	             "implementation inheritance.")]
	ObjectBased = 1 << 12,

	[Display(Name = "Block-based")]
	[Description("A block-based language is one in which the program is " +
	             "constructed by dragging blocks around, rather than typing " +
	             "text. This is a form of visual programming.")]
	BlockBased = 1 << 13,
}
