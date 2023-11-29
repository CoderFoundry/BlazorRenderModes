# BlazorRenderModes

## Screenshots
<img src="https://github.com/CoderFoundry/BlazorRenderModes/assets/6745147/6a6b0354-6a8b-4670-995b-355e872f8f1c" width="45%" align="center"> <img src="https://github.com/CoderFoundry/BlazorRenderModes/assets/6745147/249b7895-27c2-467b-b6fe-6f8aba4decd2" width="45%" align="center">

## Configuration
Blazor has 5 render modes. SSR Server Side Render, SSR Streaming Rendering, Blazor Server with SignalR, Blazor Wasm, Blazor Auto.
This repo has created demos for each render type.

The app has been built with the final release of .NET 8. To run this sample, you must download and install Visual Studio 17.8+ and the .NET 8 SDK.

Download Visual Studio
https://visualstudio.microsoft.com/vs/

Download the SDK here
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

You will also need to get a TMDB API developer key. Follow this link to get a key
https://developer.themoviedb.org/docs
*Note: TMDB will provide two keys - this sample uses the "Read Access Key" as a bearer token, not the "API Key" which must be appended as a query string.*

To add your TMDB API key to the project you will navigate to the server project and edit program.cs 
You can add your key directly to the file or use user secrets like we did. We set the string variable with the value using a user secret. 

```cs
// your TMDB Read Access key must be in the server's secrets.json, e.g.:
// "TMDBKey": "your-Read-Access-key-here"
// Alternatively, place your API key directly over builder.Configuration["TMDBKey"]
string? tmdbKey = builder.Configuration["TMDBKey"];

builder.Services.AddScoped(sp => {
    var client = new HttpClient();
    client.BaseAddress = new("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Authorization = new("Bearer", tmdbKey);
    return client;
});
```

Syntax example for User Secrets or appsettings.json:
```json
{
  "TMDBKey": "your-Read-Access-key-here"
}
```

## Blazor Overview Video

[<img src="https://github-production-user-asset-6210df.s3.amazonaws.com/1706203/266028119-0e52140c-db7c-40a9-920a-f10aa5b1f6bb.jpg" width="50%">](https://www.youtube.com/watch?v=u4azTLLGt8U "Blazor Render Modes")

## SSR Walkthrough Video
[<img src="https://github-production-user-asset-6210df.s3.amazonaws.com/1706203/267058156-b510ab99-a1a8-4f8a-8714-859425987757.png" width="50%">](https://www.youtube.com/watch?v=2kGR1lgEL50 "Blazor Render Modes")

