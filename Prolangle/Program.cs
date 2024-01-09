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
builder.Services.AddTransient<GuessGame>(sp =>
{
	var lp = sp.GetRequiredService<LanguagesProvider>();
	var logger = sp.GetRequiredService<ILogger<GuessGame>>();

	var environment = sp.GetRequiredService<IWebAssemblyHostEnvironment>();

	Console.WriteLine($"Running in {environment.Environment} environment");

	var seeder = environment.Environment switch
	{
		"Development" => DateTime.Now.Ticks,
		"Production" => DateTime.Today.Ticks,
		_ => throw new NotImplementedException()
	};

	return new(lp, logger, () => (int)(seeder % Math.Pow(2, 31)),
		environment);
});

await builder.Build().RunAsync();
