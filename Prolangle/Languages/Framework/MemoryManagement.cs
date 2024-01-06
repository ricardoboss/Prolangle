using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum MemoryManagement
{
	None,
	Other,

	[Display(Name = "Tracing garbage collection")]
	TracingGarbageCollection,

	[Display(Name = "Reference counting")]
	ReferenceCounting,

	Manual,
}
