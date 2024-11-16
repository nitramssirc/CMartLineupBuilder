using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

using UI;
using Tewr.Blazor.FileReader;
using Application.Queries.GetSlates;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Radzen;

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

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSlateQuery).Assembly));

//Radzen Components
builder.Services.AddRadzenComponents();

//DB Contexts
builder.Services.AddDbContext<SlateDbContext>(options =>
    options.UseSqlite("Data Source=cmartLineUpBuilder.db"));

//Repositories
builder.Services.Scan(scan => scan
    .FromAssemblyOf<SlateDbContext>()
    .AddClasses(classes => classes.AssignableTo<SlateDbContext>())
    .AsImplementedInterfaces()
    .WithScopedLifetime());

await builder.Build().RunAsync();
