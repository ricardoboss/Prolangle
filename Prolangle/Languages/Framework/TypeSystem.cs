namespace Prolangle.Languages.Framework;

[Flags]
public enum TypeSystem
{
	None,
	Other,
	Safe,
	Strong,
	Weak,
	Static,
	Dynamic,
	Manifest,
	Inferred,
	Nominal,
	Structural,
}
