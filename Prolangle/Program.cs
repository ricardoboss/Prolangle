using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Prolangle;
using Prolangle.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LanguageMetadataProvider>();
builder.Services.AddSingleton<LanguagesProvider>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GameHistoryService>();

builder.Services.AddTransient<GameInitializer>(sp =>
{
	var lp = sp.GetRequiredService<LanguagesProvider>();
	var logger = sp.GetRequiredService<ILogger<GameInitializer>>();
	return new(lp, logger, () => DateTime.Now.Minute);
});

await builder.Build().RunAsync();
