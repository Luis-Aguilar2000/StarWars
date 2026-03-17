using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
    public class EspecieSW
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("classification")]
        public string classification { get; set; }

        [JsonPropertyName("designation")]
        public string designation { get; set; }

        [JsonPropertyName("average_lifespan")]
        public string average_lifespan { get; set; }
    }
}
