using Newtonsoft.Json;

namespace StarWars.Dtos
{
    public class TransporteJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonProperty("cost_in_credits")]
        public string Cost { get; set; } = string.Empty;

        [JsonProperty("length")]
        public string Length { get; set; } = string.Empty;

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; } = string.Empty;

        [JsonProperty("crew")]
        public string Crew { get; set; } = string.Empty;

        [JsonProperty("passengers")]
        public string Passengers { get; set; } = string.Empty;

        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; } = string.Empty;

        [JsonProperty("consumables")]
        public string Consumables { get; set; } = string.Empty;

        [JsonProperty("MGLT")]
        public string? MGLT { get; set; }

        [JsonProperty("starship_class")]
        public string? StarshipClass { get; set; }

        [JsonProperty("vehicle_class")]
        public string? VehicleClass { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}