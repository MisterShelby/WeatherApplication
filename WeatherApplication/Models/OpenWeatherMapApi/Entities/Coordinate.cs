using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class Coordinate
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}