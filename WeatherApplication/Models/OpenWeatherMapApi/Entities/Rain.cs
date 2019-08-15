using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double RainVolume { get; set; }
    }
}