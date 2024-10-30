using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

using UI;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorageAsSingleton(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);


//Commands
//builder.Services.AddScoped(typeof(IAddWeekCommand), typeof(AddWeekCommand));
//builder.Services.AddScoped(typeof(IImportProjectionCommand), typeof(ImportProjectionCommand));

//Queries
//builder.Services.AddScoped(typeof(IGetWeeksQuery), typeof(GetWeeksQuery));
//builder.Services.AddScoped(typeof(IGetProjectionsQuery), typeof(GetProjectionsQuery));
//builder.Services.AddScoped(typeof(IGetExpertPicksQuery), typeof(GetExpertPicksQuery));

//Repos
//builder.Services.AddSingleton(typeof(IWeekRepo), typeof(WeekRepo));
//builder.Services.AddSingleton(typeof(IProjectionRepo), typeof(ProjectionRepo));

//Monitors
//builder.Services.AddSingleton(typeof(IProjectionsMonitor), typeof(ProjectionsMonitor));

await builder.Build().RunAsync();
