using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prolangle.Languages.Framework;

public enum MemoryManagement
{
	[Description("""
                 In some languages, you cannot manage memory at all. For
                 example, this can mean that all variables are always in the
                 stack, not the heap.
                 """)]
	None,

	Other,

	[Display(Name = "Tracing garbage collection")]
	[Description("In tracing garbage collection (often just called 'garbage " +
	             "collection', a mechanism continously determines at runtime " +
	             "whether objects are still \"reachable\", and, for those " +
	             "which aren't, cleans them up.")]
	[MoreInformationUrl("https://en.wikipedia.org/wiki/Tracing_garbage_collection")]
	TracingGarbageCollection,

	[Display(Name = "Reference counting")]
	[Description("Reference counting is a form of garbage collection where " +
	             "code — either written manually, or inserted by a compiler — " +
	             "increments and decrements how many times an object is " +
	             "referenced. As the count hits zero, it is assumed that the " +
	             "object's memory can be released.")]
	[MoreInformationUrl("https://en.wikipedia.org/wiki/Reference_counting")]
	ReferenceCounting,

	[Description("In manual memory management, the author of the code is " +
	             "responsible for determining when to start using memory " +
	             "for objects ('allocate' it) as well as how much, and to " +
	             "clean it up later on ('free' it).")]
	[MoreInformationUrl("https://en.wikipedia.org/wiki/Manual_memory_management")]
	Manual,
}
