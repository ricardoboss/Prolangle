using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Prolangle.Abstractions.Services;
using Prolangle.Abstractions.Snippets;
using Prolangle.Snippets.AppleScript;

namespace Prolangle.Services;

public class AssemblySnippetsProvider : ISnippetsProvider
{
	public IEnumerable<ICodeSnippet> GetAll() =>
		typeof(SimpleAppleScriptSnippet).Assembly.GetTypes()
			.Where(t => typeof(ICodeSnippet).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false })
			.Select(Activator.CreateInstance)
			.OfType<ICodeSnippet>();
}

public static class AssemblySnippetsProviderServiceCollectionExtensions
{
	[PublicAPI]
	public static IServiceCollection AddAssemblySnippetsProvider(this IServiceCollection services)
	{
		services.AddSingleton<ISnippetsProvider, AssemblySnippetsProvider>();

		return services;
	}
}
