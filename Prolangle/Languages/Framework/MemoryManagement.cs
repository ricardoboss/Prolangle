using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum MemoryManagement
{
	None,
	Other,
	[Display(Name = "Garbage collection")]
	GarbageCollection,
	Manual,
}
