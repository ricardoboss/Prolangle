using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

[Flags]
public enum Paradigms
{
	None = 0,

	[Display(Name = "Object-oriented")]
	ObjectOriented = 1 << 0,

	[Description("Functional languages focus on applying and composing " +
	             "functions. Often, a focus is put on making these as pure " +
	             "(side-effect-free) as possible.")]
	Functional = 1 << 1,

	[Description("In generic programming, code can be written against a " +
	             "template of a type, rather than a concrete type, and can " +
	             "then be applied to multiple concrete types.")]
	Generic = 1 << 2,

	[Description("Imperative programming focuses on statements, which define " +
	             "what a program does as a step-by-step recipe.")]
	Imperative = 1 << 3,

	[Description("Structured programming is a form of imperative programming " +
	             "that introduces conditions (if/then/else), loops (while, " +
	             "for) and subroutines (other functions or methods to " +
	             "be called), and organizes those in so-called blocks.")]
	Structured = 1 << 4,

	[Description("Procedural programming is a form of imperative programming " +
	             "that focuses on procedures. Depending on the context, " +
	             "these may also be referred to as functions, methods, or " +
	             "subroutines).")]
	Procedural = 1 << 5,

	[Description("In declarative programming, you focus on the abstract " +
	             "desired result rather than the concrete control flow (e.g.," +
	             "series of steps) that would lead to it.")]
	Declarative = 1 << 6,

	[Display(Name = "Event-driven")]
	[Description("Event-driven languages provide high-level facilities to " +
	             "react to external inputs, such as key presses and mouse " +
	             "clicks, or incoming network data.")]
	EventDriven = 1 << 7,

	[Description("Reflective programming is a form of metaprogramming where " +
	             "a running program can 'reflect on itself', i.e. know and " +
	             "possibly modify its own structure and behavior. For " +
	             "example, a reflective programming language may be able to " +
	             "ask itself, 'which types currently exist?', and to " +
	             "iterate over them.")]
	Reflective = 1 << 8,

	[Display(Name = "Task-driven")]
	TaskDriven = 1 << 9,

	[Description("A concurrent language offers strong language-level support " +
	             "for calls to run concurrently, i.e., for them to overlap " +
	             "each other, and still succeed safely.")]
	Concurrent = 1 << 10,

	[Display(Name = "Natural language")]
	[Description("In a natural programming language, the syntax is heavily " +
	             "inspired by 'natural languages', i.e. languages such as " +
	             "English that humans use to communicate with each other.")]
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

	[Description("An esoteric language isn't meant to be used in production " +
	             "code, but was rather designed as a proof of concept, or as a " +
	             "joke.")]
	Esoteric = 1 << 14
}
