using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }
        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }
        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }
        [JsonProperty("grnd_level")]
        public double GroundLevel { get; set; }
        [JsonProperty("temp_kf")]
        public double TempCoefficient { get; set; }
    }
}