using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Prolangle;
using Prolangle.Models.Db;
using Prolangle.Services;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();

builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
		options.ProductToken =
			"CjxRBXF3NQs8UwF3ejM1BlEAc3s1CTxaAXF+NAs7bjoNJ2ZdYhBVCCo/DTtRPUsNalV8Al44B2ECAWllMit3cWhZPUsCbFtpDUMkGnxIaVlzLiNoTWIKRDhDD2dTJ3EVD0JqRSdvHgNEYFM8Yg4ZVmdTWQFxfjUIAWlvHg9QbEMgfwweSX1YJm8eA0RgUzxiDhlWZ1NZAXF+NQgBaW8eDU15XjdjHhFIeVQ8bxMBUmtTPApwfjU1BjxvDQdWbFoqdRYRWnVNO28eHEpvXzxve381CDxTPUsRWmxeJnUXB0BvUzx9ABZaZ14sZxIRWgI9UwBxQw93YjdWandUakkaaA45YgxPLXszDDRMaxIFIgNUF2chWAIta35hL143eGB2dgpKJSlqfjsUVRIJNFNpBQA7fVBXezFDJAtTADQFVS8iNm56WgElGTULZw1ididfe1QvaDF2fVliO1MmF0wAPjJxIyFgXmANagsLZ2pkAFJ5FkBQJyleLAZdE2AnWxEAbHp+GmUxCTcXTyRaJQRCSV0GQjsgVF9vD1N4BHBhXBQN";
	})
	.AddBulmaProviders()
	.AddFontAwesomeIcons();

builder.Services.AddMudBlazorScrollSpy();

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
			currentGameTimestamp = DateTime.Today.AddHours(DateTime.Now.Hour);
			nextGameTimestamp = DateTime.Today.AddHours(DateTime.Now.Hour + 1);
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

builder.Services.AddIndexedDB(o =>
{
	o.DbName = "Prolangle";
	o.Version = 1;

	o.Stores.Add(new StoreSchema
	{
		DbVersion = 1,
		Name = Game.StoreName,
		PrimaryKey = new IndexSpec { Name = "AutoId", Auto = true },
		Indexes =
		[
			new IndexSpec { Name = nameof(Game.Id), Unique = true, Auto = false, KeyPath = nameof(Game.Id) },
			new IndexSpec { Name = nameof(Game.TypeId), Unique = false, Auto = false, KeyPath = nameof(Game.TypeId) },
			new IndexSpec
				{ Name = nameof(Game.PlayedAt), Unique = false, Auto = false, KeyPath = nameof(Game.PlayedAt) },
		],
	});

	o.Stores.Add(new StoreSchema
	{
		DbVersion = 1,
		Name = Guess.StoreName,
		PrimaryKey = new IndexSpec { Name = "AutoId", Auto = true },
		Indexes =
		[
			new IndexSpec { Name = nameof(Guess.GameId), Auto = false, KeyPath = nameof(Guess.GameId) },
			new IndexSpec { Name = nameof(Guess.PlayedAt), Auto = false, KeyPath = nameof(Guess.PlayedAt) },
			new IndexSpec { Name = nameof(Guess.LanguageId), Auto = false, KeyPath = nameof(Guess.LanguageId) },
		],
	});
});

await builder.Build().RunAsync();
