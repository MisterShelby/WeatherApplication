using System.Collections.Generic;
using WeatherApplication.Models.ForecastService;

namespace WeatherApplication.Models.CityService
{
    public interface ICityService
    {
        City GeCityByName(string cityName);

        List<City> GetCities();
    }
}
