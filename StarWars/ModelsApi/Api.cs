using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
   public class Api<T>
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("results")]
        public List<T> results { get; set; }
    }
}
