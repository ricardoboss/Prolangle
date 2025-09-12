using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Services;
using Prolangle.Languages;

namespace Prolangle.Services;

public class AssemblyLanguagesProvider : ILanguagesProvider
{
	public IEnumerable<ILanguage> GetAll()
	{
		return typeof(BaseLanguage)
			.Assembly
			.ExportedTypes
			.Where(t => t.IsAssignableTo(typeof(ILanguage)) && t is { IsClass: true, IsAbstract: false })
			.Select(l => l.GetProperty("Instance")?.GetValue(null))
			.OfType<ILanguage>();
	}
}

public static class AssemblyLanguagesProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddAssemblyLanguagesProvider(this IServiceCollection services)
	{
		services.AddSingleton<ILanguagesProvider, AssemblyLanguagesProvider>();

		return services;
	}
}
