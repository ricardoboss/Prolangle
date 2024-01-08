using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Prolangle;
using Prolangle.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();

builder.Services
	.AddBlazorise( options =>
	{
		options.Immediate = true;
		// options.ProductToken = // TODO: pending request for license
	} )
	.AddBulmaProviders()
	.AddFontAwesomeIcons();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LanguageMetadataProvider>();
builder.Services.AddSingleton<LanguagesProvider>();
builder.Services.AddTransient<GuessGame>(sp =>
{
	var lp = sp.GetRequiredService<LanguagesProvider>();
	var logger = sp.GetRequiredService<ILogger<GuessGame>>();
	return new(lp, logger, () => DateTime.Now.Minute);
});

await builder.Build().RunAsync();
