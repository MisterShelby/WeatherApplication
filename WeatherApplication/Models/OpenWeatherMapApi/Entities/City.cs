﻿using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coordinate Coordinate { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
    }
}