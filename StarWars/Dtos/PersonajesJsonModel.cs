using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWars.Dtos
{
    public class PersonajeJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; } = string.Empty;

        [JsonProperty("films")]
        public List<string> Films { get; set; } = new List<string>();

        [JsonProperty("species")]
        public List<string> Species { get; set; } = new List<string>();

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; } = new List<string>();

        [JsonProperty("starships")]
        public List<string> Starships { get; set; } = new List<string>();

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}