using Application.Queries.GetSlates;
using Application.Specifications.Factory;

using Microsoft.EntityFrameworkCore;

using Radzen;

using Repository.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSlateQuery).Assembly));

//Radzen Components
builder.Services.AddRadzenComponents();

//DB Contexts
builder.Services.AddDbContext<CMartDbContext>(options =>
    options.UseSqlite("Data Source=cmartLineUpBuilder.db"));

//Repositories
builder.Services.Scan(scan => scan
    .FromAssemblyOf<CMartDbContext>()
    .AddClasses(classes => classes.InNamespaces("Repository.Repositories"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

//Application
builder.Services.AddScoped<ISpecificationFactory, SpecificationFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
