using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Dtos
{
    public class VehiculoJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("cost_in_credits")]
        public string Cost { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [JsonProperty("crew")]
        public string Crew { get; set; }


        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        [JsonProperty("cargo_Capacity")]
        public string CargoCapacity { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }
    }
}
