namespace Prolangle.Languages.Framework;

[Flags]
public enum Paradigms
{
	None = 0,
	ObjectOriented = 1 << 0,
	Functional = 1 << 1,
	Generic = 1 << 2,
	Imperative = 1 << 3,
	Structured = 1 << 4,
	Procedural = 1 << 5,
	Declarative = 1 << 6,
	EventDriven = 1 << 7,
	Reflective = 1 << 8,
	TaskDriven = 1 << 9,
	Concurrent = 1 << 10,
}
