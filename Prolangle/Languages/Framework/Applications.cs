namespace Prolangle.Languages.Framework;

[Flags]
public enum Applications
{
	None = 0,
	Other = 1 << 0,
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
}
