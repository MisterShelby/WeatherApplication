using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class OpenWeatherResponse
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<List> List { get; set; }
        [JsonProperty("city")]
        public City City { get; set; }
    }
}