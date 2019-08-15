using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class List
    {
        [JsonProperty("dt")]
        public int DataOfForecasted { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string DateTimeOfCalculation { get; set; }
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
    }
}