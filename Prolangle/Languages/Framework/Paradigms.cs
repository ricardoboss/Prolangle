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
	NaturalLanguage = 1 << 11
}
