using Newtonsoft.Json;

public class PeliculaJsonModel
{
    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("episode_id")]
    public int EpisodeId { get; set; }

    [JsonProperty("opening_crawl")]
    public string OpeningCrawl { get; set; } = string.Empty;

    [JsonProperty("director")]
    public string Director { get; set; } = string.Empty;

    [JsonProperty("producer")]
    public string Producer { get; set; } = string.Empty;

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonProperty("characters")]
    public List<string> Characters { get; set; } = new();

    [JsonProperty("vehicles")]
    public List<string> Vehicles { get; set; } = new();

    [JsonProperty("starships")]
    public List<string> Starships { get; set; } = new();

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}