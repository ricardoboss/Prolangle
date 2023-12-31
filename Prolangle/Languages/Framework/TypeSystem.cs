namespace Prolangle.Languages.Framework;

[Flags]
public enum TypeSystem
{
	None = 0,
	Other = 1 << 0,
	Safe = 1 << 1,
	Strong = 1 << 2,
	Weak = 1 << 3,
	Static = 1 << 4,
	Dynamic = 1 << 5,
	Manifest = 1 << 6,
	Inferred = 1 << 7,
	Nominal = 1 << 8,
	Structural = 1 << 9,
	Duck = 1 << 10,
}
