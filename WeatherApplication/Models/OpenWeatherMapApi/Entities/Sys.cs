using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}