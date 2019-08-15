using Newtonsoft.Json;

namespace WeatherApplication.Models.DarkSkyApi
{
    public class DarkSkyResponse
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}