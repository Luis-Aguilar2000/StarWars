using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Api
{
    public class PeliculaSW
    {
       
            [JsonPropertyName("title")]
            public string title { get; set; }

            [JsonPropertyName("episode_id")]
            public int episode_id { get; set; }

            [JsonPropertyName("opening_crawl")]
            public string opening_crawl { get; set; }

            [JsonPropertyName("director")]
            public string director { get; set; }

            [JsonPropertyName("producer")]
            public string producer { get; set; }

            [JsonPropertyName("release_date")]
            public string release_date { get; set; }
        
    }
}
