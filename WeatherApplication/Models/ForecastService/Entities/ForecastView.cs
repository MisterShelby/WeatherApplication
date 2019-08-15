using System;

namespace WeatherApplication.Models.ForecastService
{
    public class ForecastView
    {
        public string Icon { get; set; }

        public double Temperature { get; set; }

        public DateTime Time { get; set; }

    }
}