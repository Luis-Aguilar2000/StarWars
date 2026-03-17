using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
    public class PersonajeSW
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("height")]
        public string height { get; set; }

        [JsonPropertyName("mass")]
        public string mass { get; set; }

        [JsonPropertyName("skin_color")]
        public string skin_color { get; set; }

        [JsonPropertyName("eye_color")]
        public string eye_color { get; set; }

        [JsonPropertyName("hair_color")]
        public string hair_color { get; set; }

        [JsonPropertyName("birth_year")]
        public string birth_year { get; set; }

        [JsonPropertyName("gender")]
        public string gender { get; set; }

        [JsonPropertyName("homeworld")]
        public string homeworld { get; set; }

        [JsonPropertyName("films")]
        public List<string> films { get; set; }

        [JsonPropertyName("vehicles")]
        public List<string> vehicles { get; set; }
    }
}

