using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
    public class NaveSW
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("model")]
        public string model { get; set; }

        [JsonPropertyName("manufacturer")]
        public string manufacturer { get; set; }

        [JsonPropertyName("length")]
        public string length { get; set; }

        [JsonPropertyName("cost_in_credits")]
        public string cost_in_credits { get; set; }

        [JsonPropertyName("max_atmosphering_speed")]
        public string max_atmosphering_speed { get; set; }

        [JsonPropertyName("crew")]
        public string crew { get; set; }

        [JsonPropertyName("passengers")]
        public string passengers { get; set; }

        [JsonPropertyName("cargo_capacity")]
        public string cargo_capacity { get; set; }

        [JsonPropertyName("consumables")]
        public string consumables { get; set; }

        [JsonPropertyName("MGLT")]
        public string MGLT { get; set; }

        [JsonPropertyName("hyperdrive_rating")]
        public string hyperdrive_rating { get; set; }
    }
}

