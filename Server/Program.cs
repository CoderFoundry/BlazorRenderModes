using Server;
using Server.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// your TMDB Read Access key must be in the server's secrets.json, e.g.:
// "TMDBKey": "your-API-key-here"
string tmdbKey = builder.Configuration["TMDBKey"];
var settings = new Client.Models.AppSettings { TMDBKey = tmdbKey };
builder.Services.AddSingleton(settings);

// The movie API changed how it works? I'm not sure, but adding a query parameter works for me and a bearer token does not.
builder.Services.AddScoped(sp => {
    var client = new HttpClient();
    client.BaseAddress = new("https://api.themoviedb.org/3/");
    return client;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

app.MapGet("/movie/popular", async ([FromServices] HttpClient http) =>
{
    PopularMovieResponse? response = await http.GetFromJsonAsync<PopularMovieResponse>($"movie/popular?api_key={tmdbKey}");

    return response is not null ? Results.Ok(response) : Results.Problem();
});

app.MapGet("/movie/{id}", async ([FromServices] HttpClient http, int? id) =>
{
    if (id.HasValue)
    {
        MovieDetails? response = await http.GetFromJsonAsync<MovieDetails?>($"movie/{id.Value}?api_key={tmdbKey}");

        return Results.Ok(response);
    }

    return Results.BadRequest();
});

app.Run();
