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
	.AddBlazorise(options =>
	{
		options.Immediate = true;
		options.ProductToken =
			"CjxRBHF/NQE9UgB0fjQ1BlEAc3s1CTxaAXF+NAs7bjoNJ2ZdYhBVCCo/DTtRPUsNalV8Al44B2ECAWllMit3cWhZPUsCbFtpDUMkGnxIaVlzLiNoTWIKRDhDD2dTJ3EVD0JqRSdvHgNEYFM8Yg4ZVmdTWQFxfjUIAWlvHg9QbEMgfwweSX1YJm8eA0RgUzxiDhlWZ1NZAXF+NQgBaW8eDU15XjdjHhFIeVQ8bxMBUmtTPApwfjU1BjxvDQdWbFoqdRYRWnVNO28eHEpvXzxve381CDxTPUsRWmxeJnUXB0BvUzx9ABZaZ14sZxIRWgI9UwBxQw9oPQsGMARLTV0aYyAXM1d2LQJwNEhhdSp3dApKTmgMaSxhT39lGnxzfGcPQDRZcAdwXnouZHgeZwFkKEoFGHR2SDFnEgBcfXwmVQsdVUF+AFURZU52TwxFIjldb2sEAww0Q196Mnh3PGAPRhJSLQE1bD1VYTQLUXdOFFImHEZxI1p5KBZdUTU2V242SXJWUhsuN0cJdCQBcykwcHoEAQ8HU1JENlZ4F3BISQAN";
	})
	.AddBulmaProviders()
	.AddFontAwesomeIcons();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LanguageMetadataProvider>();
builder.Services.AddSingleton<LanguagesProvider>();
builder.Services.AddSingleton<GameSeeder>(sp =>
{
	var logger = sp.GetRequiredService<ILogger<GameSeeder>>();

	var environment = sp.GetRequiredService<IWebAssemblyHostEnvironment>();

	logger.LogInformation("Running in {Environment} environment", environment.Environment);

	DateTime currentGameTimestamp, nextGameTimestamp;

	switch (environment.Environment)
	{
		case "Development":
			currentGameTimestamp = DateTime.Now;
			nextGameTimestamp = DateTime.Now.AddHours(1);
			break;
		case "Production":
			currentGameTimestamp = DateTime.Today;
			nextGameTimestamp = DateTime.Today.AddDays(1);
			break;
		default:
			throw new NotImplementedException();
	}

	var seeder = (int)(currentGameTimestamp.Ticks % Math.Pow(2, 31));

	return new GameSeeder(() => seeder, currentGameTimestamp, nextGameTimestamp);
});

builder.Services.AddSingleton<LanguageSnippetProvider>(sp =>
{
	var seeder = sp.GetRequiredService<GameSeeder>();

	return new LanguageSnippetProvider(seeder);
});

builder.Services.AddSingleton<GuessGame>(sp =>
{
	var lp = sp.GetRequiredService<LanguagesProvider>();
	var logger = sp.GetRequiredService<ILogger<GuessGame>>();

	var environment = sp.GetRequiredService<IWebAssemblyHostEnvironment>();

	var seeder = sp.GetRequiredService<GameSeeder>();

	var snippetProvider = sp.GetRequiredService<LanguageSnippetProvider>();

	return new GuessGame(lp, snippetProvider, logger, seeder, environment);
});

await builder.Build().RunAsync();
