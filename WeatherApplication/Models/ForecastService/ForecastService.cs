using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Models.CityService;
using WeatherApplication.Models.DarkSkyApi;
using WeatherApplication.Models.OpenWeatherMapApi;

namespace WeatherApplication.Models.ForecastService
{
    public class ForecastService : IForecastService
    {
        private readonly IOpenWeatherMapApi _openWeatherMapApi;
        private readonly IDarkSkyApi _darkSkyApi;
        private readonly ICityService _cityService;

        public ForecastService(IOpenWeatherMapApi openWeatherMapApi, IDarkSkyApi darkSkyApi, ICityService cityService)
        {
            _openWeatherMapApi = openWeatherMapApi;
            _darkSkyApi = darkSkyApi;
            _cityService = cityService;
        }
        public async Task<ForecastResultView> GetForecast(ForecastParam param)
        {

            var city = getCity(param.City);

            if (city == null)
            {
                return null;
            }

            while (true)
            {

                var darkSkyParam = getDarkSkyApiParam(city);

                var darkSkyResponse = await _darkSkyApi.GetForecast(darkSkyParam);

                var resultFromDarkSkyApi = getForecastResultView(darkSkyResponse);

                if (resultFromDarkSkyApi == null)
                {

                    var openWeatherParam = getOpenWeatherParam(city);

                    var forecast = await _openWeatherMapApi.getDailyForecast(openWeatherParam);

                    var resultFromOpenWeather = getForecastResultView(forecast);

                    return resultFromOpenWeather;
                }

                return resultFromDarkSkyApi;
            }



        }

        private ForecastResultView getForecastResultView(OpenWeatherResponse response)
        {
            var openWeatherList = response.List;

            if (openWeatherList.Count == default)
            {
                return null;
            }
            var result = new ForecastResultView();

            var pressure = Math.Round(openWeatherList.Sum(x => x.Main.Pressure) / openWeatherList.Count,3);

            result.AveragePressure = pressure;

            var forecastView = openWeatherList.Select(x => new ForecastView
            {
                Time = Convert.ToDateTime(x.DateTimeOfCalculation),
                Temperature = x.Main.Temperature,
                Icon = x.Rain == null ? "no rain" : "rain"
            }).ToList();

            var forecast = getView(forecastView);

            result.AverageTemperatures = forecast.AverageTemperatures;
            result.RainDays = forecast.RainDays;



            return result;

        }

        private ForecastResultView getForecastResultView(DarkSkyResponse darkSkyResponse)
        {
            var response = darkSkyResponse;
            var result = new ForecastResultView();

            if (response?.Hourly?.Data == null)
            {
                return null;
            }


            var averagePressure = Math.Round(response.Hourly.Data.Sum(x => x.Pressure) / response.Hourly.Data.Count,3);

            result.AveragePressure = averagePressure;

            var forecastByDays = response.Hourly.Data.Select(x => new ForecastView
                {Time = unixTimeStampToDateTime(x.Time),Temperature = x.Temperature, Icon = x.Icon}).ToList();

            var resultView = getView(forecastByDays.ToList());

            result.AverageTemperatures = resultView.AverageTemperatures;

            result.RainDays = resultView.RainDays;

            return result;
        }

        private ForecastResultView getView(IEnumerable<ForecastView> forecastViews)
        {
            var result = new ForecastResultView();
            var forecast = forecastViews.ToList();
            var averageTempByDays = forecast.GroupBy(x => x.Time.ToShortDateString())
                .Select(x => new AverageTemperature
                {
                    Temperature = Math.Round(x.Sum(y => y.Temperature) / x.Count(), 3),
                    Day = x.First().Time.ToShortDateString()
                }).ToList();

            result.AverageTemperatures.AddRange(averageTempByDays);

            for (int i = 0; i < forecast.Count; i++)
            {
                if (forecast[i].Icon == "rain")
                {
                    var rainday = new RainDay
                    {
                        RainDate = forecast[i].Time.ToShortDateString(),
                        StartTime = forecast[i].Time.ToString()
                    };
                    for (int j = i; j < forecast.Count; j++)
                    {
                        if (forecast[j].Icon != "rain")
                        {
                            rainday.EndTime = forecast[j].Time.ToString();
                            result.RainDays.Add(rainday);
                            i = j;
                            break;
                        }
                    }
                }
            }

            return result;
        }


        private City getCity(string cityName)
        {
            var name = cityName;

            var city = _cityService.GeCityByName(name);



            return city;
        }

        private DateTime unixTimeStampToDateTime(double unixTimeStamp)
        {
            var datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            datetime = datetime.AddSeconds(unixTimeStamp).ToLocalTime();
            return datetime;
        }

        private OpenWeatherParam getOpenWeatherParam(City city)
        {
            var param = new OpenWeatherParam
            {
                City = city.Name,
                CountryCode = city.Country
            };

            return param;
        }


        private DarkSkyApiParam getDarkSkyApiParam(City city)
        {
            var param = new DarkSkyApiParam
            {
                Latitude = city.Coordinate.Latitude,
                Longitude = city.Coordinate.Longitude
            };

            return param;
        }
    }
}