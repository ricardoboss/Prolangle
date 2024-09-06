using System.Text.Json.Serialization.Metadata;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Prolangle;
using Prolangle.Interfaces;
using Prolangle.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();

builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
		options.ProductToken =
			"CjxRBHF/NQE9UgB0fjQ1BlEAc3s1CTxaAXF+NAs7bjoNJ2ZdYhBVCCo/DTtRPUsNalV8Al44B2ECAWllMit3cWhZPUsCbFtpDUMkGnxIaVlzLiNoTWIKRDhDD2dTJ3EVD0JqRSdvHgNEYFM8Yg4ZVmdTWQFxfjUIAWlvHg9QbEMgfwweSX1YJm8eA0RgUzxiDhlWZ1NZAXF+NQgBaW8eDU15XjdjHhFIeVQ8bxMBUmtTPApwfjU1BjxvDQdWbFoqdRYRWnVNO28eHEpvXzxve381CDxTPUsRWmxeJnUXB0BvUzx9ABZaZ14sZxIRWgI9UwBxQw9oPQsGMARLTV0aYyAXM1d2LQJwNEhhdSp3dApKTmgMaSxhT39lGnxzfGcPQDRZcAdwXnouZHgeZwFkKEoFGHR2SDFnEgBcfXwmVQsdVUF+AFURZU52TwxFIjldb2sEAww0Q196Mnh3PGAPRhJSLQE1bD1VYTQLUXdOFFImHEZxI1p5KBZdUTU2V242SXJWUhsuN0cJdCQBcykwcHoEAQ8HU1JENlZ4F3BISQAN";
	})
	.AddBulmaProviders()
	.AddFontAwesomeIcons();

builder.Services.AddMudBlazorScrollSpy();

builder.Services.AddBlazoredLocalStorageAsSingleton(o =>
{
	foreach (IJsonTypeInfoResolver resolver in AppSerializerContext.Default.Options.TypeInfoResolverChain)
		o.JsonSerializerOptions.TypeInfoResolverChain.Add(resolver);
});
builder.Services.AddSingleton<IGameHistoryManager, LocalStorageGameHistoryManager>();
builder.Services.AddSingleton<IGuessGameProvider, DefaultGuessGameProvider>();
builder.Services.AddSingleton<ISnippetsProvider, DefaultSnippetsProvider>();

builder.Services.AddSingleton<DefaultTargetChooser>();
builder.Services.AddSingleton<ITargetLanguageChooser>(sp => sp.GetRequiredService<DefaultTargetChooser>());
builder.Services.AddSingleton<ITargetSnippetChooser>(sp => sp.GetRequiredService<DefaultTargetChooser>());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ILanguagesProvider, LanguagesProvider>();

await builder.Build().RunAsync();
