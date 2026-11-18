using Jeu.Core.Services;
using Jeu.Core.Repositories;
using JeuWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ISauvegardeService, SauvegardeService>();

// Enregistrement du repository des sauvegardes (existant)
builder.Services.AddScoped<ISauvegardeRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var conn = configuration.GetConnectionString("towerdeadfence");
    return new SauvegardeRepository(conn);
});

// Enregistrement du repository utilisateurs en utilisant la classe existante
builder.Services.AddScoped<IUtilisateursRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var conn = configuration.GetConnectionString("towerdeadfence");
    return new UtilisateursRepository(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
