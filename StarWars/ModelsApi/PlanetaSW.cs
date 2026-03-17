using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
    public class PlanetaSW
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("rotation_period")]
        public string rotation_period { get; set; }

        [JsonPropertyName("orbital_period")]
        public string orbital_period { get; set; }

        [JsonPropertyName("diameter")]
        public string diameter { get; set; }

        [JsonPropertyName("climate")]
        public string climate { get; set; }

        [JsonPropertyName("gravity")]
        public string gravity { get; set; }

        [JsonPropertyName("terrain")]
        public string terrain { get; set; }

        [JsonPropertyName("surface_water")]
        public string surface_water { get; set; }

        [JsonPropertyName("population")]
        public string population { get; set; }
    }
}

