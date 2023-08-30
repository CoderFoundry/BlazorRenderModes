using System.Text.Json.Serialization;

namespace Client.Models
{
    public class MovieDetails
    {
        
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }
        
        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }
        
        [JsonPropertyName("budget")]
        public int Budget { get; set; }
        
        [JsonPropertyName("genres")]
        public Genre[] Genres { get; set; } = Array.Empty<Genre>();
        
        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }
        
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("imdb_id")]
        public string? ImdbId { get; set; }
        
        [JsonPropertyName("original_language")]
        public string? OriginalLanguage { get; set; }
        
        [JsonPropertyName("original_title")]
        public string? OriginalTitle { get; set; }
        
        [JsonPropertyName("overview")]
        public string? Overview { get; set; }
        
        [JsonPropertyName("popularity")]
        public float Popularity { get; set; }
        
        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
        
        [JsonPropertyName("production_companies")]
        public ProductionCompanies[] ProductionCompanies { get; set; } = Array.Empty<ProductionCompanies>();
        
        [JsonPropertyName("production_countries")]
        public ProductionCountries[] ProductionCountries { get; set; } = Array.Empty<ProductionCountries>();
        
        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }
        
        [JsonPropertyName("revenue")]
        public int Revenue { get; set; }
        
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
        
        [JsonPropertyName("spoken_languages")]
        public SpokenLanguages[] SpokenLanguages { get; set; } = Array.Empty<SpokenLanguages>();
        
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        
        [JsonPropertyName("tagline")]
        public string? Tagline { get; set; }
        
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        
        [JsonPropertyName("video")]
        public bool Video { get; set; }
        
        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; set; }
        
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }

    public class Genre
    {   
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class ProductionCompanies
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("logo_path")]
        public string? LogoPath { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("origin_country")]
        public string? OriginCountry { get; set; }
    }

    public class ProductionCountries
    {   
        [JsonPropertyName("iso_3166_1")]
        public string? LanguageCode { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class SpokenLanguages
    {
        [JsonPropertyName("english_name")]
        public string? EnglishName { get; set; }
        
        [JsonPropertyName("iso_639_1")]
        public string? LanguageCode { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

}

