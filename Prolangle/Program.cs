using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Prolangle;
using Prolangle.Services;
using Prolangle.Services.Games;
using Prolangle.Services.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLogging();

builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
		options.ProductToken =
			"CjxRBXB/Ngg9UQFwfz01BlEAc3g0CT9TAXB/NQw/bjoNJ2ZdYhBVCCo/DTtRPUsNalV8Al44B2ECAWllMit3cWhZPUsCbFtpDUMkGnxIaVlzLiNoTWIKRDhDD2dTJ3EVD0JqRSdvHgNEYFM8Yg4ZVmdTWQFxfjU1BjxvABtRd08sfRECQGxJPG8MD11nUzF/Fh1aZzZSAHF+CDJTPHMJD1dsXzxvDA9dZ1MxfxYdWmc2UgBMRFpnQCpjFRhMfVs8bwwPXWdTMX8WHVpnNlIAcX4IMlM8ZBMLQG5FJmceEUh5VDxvEwFSa1M8CnB+NTUGLHIwGzdaNRNYFB1XaXpUfQQgX1RmFkUFZWBtYhlcDT08aGEAXSg+Lk9cVGIodlVzbQlTKns8Tms1XC8CblA/MEgKFDAJbQsINyxXc08RBRV6UVRqBxsweDENeQpXIiozbzsgZDEUR1RFNBsQflUNZRZXERRJVDVXRCQPNExlTF8CIGx0OwV7dD1IbWssd3F4MxNJG3ssdnMAeFBEKQoyfUkyAzkKd1NpJ2Iicw==";
	})
	.AddBulmaProviders()
	.AddFontAwesomeIcons();

builder.Services.AddMudBlazorScrollSpy();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDefaultLanguageMetadataProvider();
builder.Services.AddAssemblyLanguagesProvider();
builder.Services.AddAssemblySnippetsProvider();
#if DEBUG
builder.Services.AddTimeBasedHourlyGameSeedProvider();
#else
builder.Services.AddTimeBasedDailyGameSeedProvider();
#endif
builder.Services.AddPropertiesLanguageComparer();
builder.Services.AddSeededSnippetChooser();
builder.Services.AddSeededLanguageChooser();
builder.Services.AddGeneralTokenTypeHighlighters();
builder.Services.AddGeneralPurposeCodeTokenizer();
builder.Services.AddDefaultConcealingTokenizerFactory();
builder.Services.AddTokenBasedCodeConcealer();
builder.Services.AddIndexedDbDatabase("Prolangle", 1, [typeof(GameEntity), typeof(GuessEntity)]);
builder.Services.AddDatabasePropertiesGameController();
builder.Services.AddDatabaseSnippetsGameController();

// builder.Services.AddIndexedDB(o =>
// {
// 	o.DbName = "Prolangle";
// 	o.Version = 1;
//
// 	o.Stores.Add(new StoreSchema
// 	{
// 		DbVersion = 1,
// 		Name = Game.StoreName,
// 		PrimaryKey = new IndexSpec { Name = "AutoId", Auto = true },
// 		Indexes =
// 		[
// 			new IndexSpec { Name = nameof(Game.Id), Unique = true, Auto = false, KeyPath = nameof(Game.Id) },
// 			new IndexSpec { Name = nameof(Game.TypeId), Unique = false, Auto = false, KeyPath = nameof(Game.TypeId) },
// 			new IndexSpec
// 				{ Name = nameof(Game.PlayedAt), Unique = false, Auto = false, KeyPath = nameof(Game.PlayedAt) },
// 		],
// 	});
//
// 	o.Stores.Add(new StoreSchema
// 	{
// 		DbVersion = 1,
// 		Name = Guess.StoreName,
// 		PrimaryKey = new IndexSpec { Name = "AutoId", Auto = true },
// 		Indexes =
// 		[
// 			new IndexSpec { Name = nameof(Guess.GameId), Auto = false, KeyPath = nameof(Guess.GameId) },
// 			new IndexSpec { Name = nameof(Guess.PlayedAt), Auto = false, KeyPath = nameof(Guess.PlayedAt) },
// 			new IndexSpec { Name = nameof(Guess.LanguageId), Auto = false, KeyPath = nameof(Guess.LanguageId) },
// 		],
// 	});
// });

await builder.Build().RunAsync();
