using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApplication.Models.DarkSkyApi
{
    public class Hourly
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
}