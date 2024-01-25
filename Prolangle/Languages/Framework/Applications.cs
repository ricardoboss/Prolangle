using System.ComponentModel;

namespace Prolangle.Languages.Framework;

[Flags]
public enum Applications
{
	None = 0,
	Other = 1 << 0,

	[Description("This language is commonly used to write mobile applications, like Android or iOS apps.")]
	Mobile = 1 << 1,
	Apple = 1 << 2,
	General = 1 << 3,
	Client = 1 << 4,
	Server = 1 << 5,
	Microsoft = 1 << 6,
	Games = 1 << 7,
	Web = 1 << 8,
	System = 1 << 9,
	Desktop = 1 << 10,
	Fun = 1 << 11,
	Education = 1 << 12,
	Ai = 1 << 13,
	Science = 1 << 14,
	Scripts = 1 << 15,

	[Description("This language is commonly used as a textual settings format.")]
	Configuration = 1 << 16,

	[Description("This language is commonly used to write/describe documents.")]
	Documents = 1 << 17,
}
