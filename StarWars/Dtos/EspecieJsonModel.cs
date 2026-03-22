using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Dtos
{
    public class EspecieJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("average_height")]
        public string AverageHeight { get; set; }

        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; }

        [JsonProperty("hair_colors")]
        public string HairColors { get; set; }

        [JsonProperty("eye_colors")]
        public string EyeColors { get; set; }

        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld {  get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        

    }
}
