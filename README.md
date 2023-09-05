# BlazorRenderModes

Blazor has 5 render modes. SSR Server Side Render, SSR Streaming Rendering, Blazor Server with SignalR, Blazor Wasm, Blazor Auto.
This repo has created demos for each render type.

The app has been built with .net 8 preview 7. You will need to download and install Visual Studio Preview and the .net 8 SDK to be able to run the sample.

Download Visual Studio Preview
https://visualstudio.microsoft.com/vs/preview/#download-preview

Download the SDK here
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

You will also need to get a TMDBApi developer key. Follow this link to get a key
https://developer.themoviedb.org/docs

To add your TMDBAPI key to the project you will navigate to the server project and edit program.cs 
You can add your key to the file or use user secrets like we did. We set the string variable with the value using a user secret. 

``` cpp
// your TMDB Read Access key must be in the server's secrets.json, e.g.:
// "TMDBKey": "your-API-key-here"
string tmdbKey = builder.Configuration["TMDBKey"];

builder.Services.AddScoped(sp => {
    var client = new HttpClient();
    client.BaseAddress = new("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Authorization = new("Bearer", tmdbKey);
    return client;
});
```


