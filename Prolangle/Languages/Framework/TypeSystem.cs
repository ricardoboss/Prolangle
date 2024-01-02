using System.ComponentModel;

namespace Prolangle.Languages.Framework;

[Flags]
public enum TypeSystem
{
	None = 0,
	Other = 1 << 0,
	Safe = 1 << 1,

	Strong = 1 << 2,
	Weak = 1 << 3,

	[Description("In a static type system, type information is resolved " +
	             "during the compile step. This is in contrast to a dynamic " +
	             "system, where it is resolved at runtime.")]
	Static = 1 << 4,

	[Description("In a dynamic type system, type information is resolved at " +
	             "runtime. This is in contrast to a static system, where it is " +
	             "resolved at compile time.")]
	[MoreInformationUrl("https://en.wikipedia.org/wiki/Type_system#Dynamic_type_checking_and_runtime_type_information")]
	Dynamic = 1 << 5,

	[Description("In a manifest type system, type information is explicitly " +
	             "declared. This is in contrast to an inferred system, where " +
	             "the compiler guesses the type based on context.")]
	Manifest = 1 << 6,

	[Description("In type inference, the compiler can determine the type " +
	             "automatically based on context. For example, if you " +
	             "initialize a variable with an integer literal, the " +
	             "compiler might infer that the variable is an integer. " +
	             "This is in contrast to a manifest system, where the " +
	             "type must be explicitly declared.")]
	Inferred = 1 << 7,

	[Description("In nominal typing, a type is determined based on its " +
	             "explicit name. This is in contrast to structural typing.")]
	Nominal = 1 << 8,

	[Description("In structural typing, if a variable's structure (for " +
	             "example, its properties) match that of another variable, " +
	             "they are considered the same type. This is in contrast to " +
	             "nominal typing.")]
	Structural = 1 << 9,

	[Description("In duck typing, if a variable walks like a duck and it " +
	             "quacks like a duck, then it must be a duck. In other " +
	             "words, the compiler guesses the type based on how it " +
	             "behaves.")]
	Duck = 1 << 10,
}
