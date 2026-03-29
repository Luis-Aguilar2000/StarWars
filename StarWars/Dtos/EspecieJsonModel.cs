using Newtonsoft.Json;

namespace StarWars.Dtos
{
    public class EspecieJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("classification")]
        public string Classification { get; set; } = string.Empty;

        [JsonProperty("designation")]
        public string Designation { get; set; } = string.Empty;

        [JsonProperty("average_height")]
        public string AverageHeight { get; set; } = string.Empty;

        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; } = string.Empty;

        [JsonProperty("hair_colors")]
        public string HairColors { get; set; } = string.Empty;

        [JsonProperty("eye_colors")]
        public string EyeColors { get; set; } = string.Empty;

        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; } = string.Empty;

        [JsonProperty("language")]
        public string Language { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}