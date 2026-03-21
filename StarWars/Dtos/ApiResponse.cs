using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWars.Dtos
{
    public class PeopleResponse<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}