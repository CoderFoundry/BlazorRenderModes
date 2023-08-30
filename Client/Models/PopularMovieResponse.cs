using System.Text.Json.Serialization;

namespace Client.Models
{
    public class PopularMovieResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<PopularMovie> Results { get; set; } = new();
    }
}
