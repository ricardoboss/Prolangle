using System.ComponentModel;

namespace Prolangle.Languages.Framework;

[Flags]
public enum Applications
{
	None = 0,
	Other = 1 << 0,

	[Description("This language is commonly used to write mobile applications, like Android or iOS apps.")]
	Mobile = 1 << 1,

	[Description("This language is commonly used to write applications for Apple devices, such as iPhones and Macs.")]
	Apple = 1 << 2,

	[Description("This language can be used to write applications for a wide variety of purposes or is not known to be used for a specific purpose.")]
	General = 1 << 3,

	[Description("This language is commonly used to write applications for client computers, such as desktops, laptops and mobile devices.")]
	Client = 1 << 4,

	[Description("This language is commonly used to write applications for servers.")]
	Server = 1 << 5,

	[Description("This language is commonly used to write applications for Microsoft devices, such as Windows computers and Xboxes.")]
	Microsoft = 1 << 6,

	[Description("Games are known to be written in this language.")]
	Games = 1 << 7,

	[Description("This language is commonly used to write applications for the web, such as websites and web applications.")]
	Web = 1 << 8,

	[Description("This language is commonly used to write kernel modules and other low-level software, like drivers.")]
	System = 1 << 9,

	[Description("This language is commonly used to write (GUI) applications for desktop computers.")]
	Desktop = 1 << 10,

	[Description("Most applications written in this language - or even the language itself - are meant to be fun or entertaining.")]
	Fun = 1 << 11,

	[Description("This language is commonly used to write applications for education purposes.")]
	Education = 1 << 12,

	[Description("This language is commonly used to write applications for training, developing and using artificial intelligence.")]
	Ai = 1 << 13,

	[Description("This language is commonly used to write applications for scientific purposes.")]
	Science = 1 << 14,

	[Description("This language is commonly used to write scripts, which are usually interpreted at runtime.")]
	Scripts = 1 << 15,

	[Description("This language is commonly used as a textual settings format.")]
	Configuration = 1 << 16,

	[Description("This language is commonly used to write/describe documents.")]
	Documents = 1 << 17,
}
