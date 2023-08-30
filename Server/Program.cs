using Server;
using Server.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();

// your TMDB Read Access key must be in the server's secrets.json, e.g.:
// "TMDBKey": "your-API-key-here"
string tmdbKey = builder.Configuration["TMDBKey"];

builder.Services.AddScoped(sp => {
    var client = new HttpClient();
    client.BaseAddress = new("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Authorization = new("Bearer", tmdbKey);
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

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();

app.MapGet("/movie/popular", async ([FromServices] HttpClient http) =>
{
    PopularMovieResponse? response = await http.GetFromJsonAsync<PopularMovieResponse>("movie/popular");

    return response is not null ? Results.Ok(response) : Results.Problem();
});

app.MapGet("/movie/{id}", async ([FromServices] HttpClient http, int? id) =>
{
    if (id.HasValue)
    {
        MovieDetails? response = await http.GetFromJsonAsync<MovieDetails?>($"movie/{id.Value}");

        return Results.Ok(response);
    }

    return Results.BadRequest();
});

app.Run();
