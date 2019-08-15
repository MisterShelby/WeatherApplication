using System;
using System.Collections.Generic;

namespace WeatherApplication.Models.ForecastService
{
    public class ForecastResultView
    
    {
        public ForecastResultView()
        {
            AverageTemperatures = new List<AverageTemperature>();
            RainDays = new List<RainDay>();
        }
        public double AveragePressure { get; set; }

        public List<RainDay> RainDays { get; set; }

        public List<AverageTemperature> AverageTemperatures { get; set; }


    }

    public class RainDay
    {
        public string RainDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }

    public class AverageTemperature
    {
        public string Day { get; set; }

        public double Temperature { get; set; }
    }

}