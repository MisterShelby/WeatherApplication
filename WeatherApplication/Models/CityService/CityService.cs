using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeatherApplication.Models.ForecastService;

namespace WeatherApplication.Models.CityService
{
    public class CityService : ICityService
    {
        private static List<City> _currentCacheCities { get; set; }

        private IEnumerable<City> _cities
        {
            get
            {
                if (_currentCacheCities != null)
                {
                    return _currentCacheCities;
                }
                _currentCacheCities = JsonConvert.DeserializeObject<List<City>>(File.ReadAllText(@"c:\city.list.json"));
                return _currentCacheCities ?? new List<City>();
            }
        }

        public City GeCityByName(string cityName)
        {
            var result = _cities.FirstOrDefault(x => string.Equals(x.Name, cityName, StringComparison.CurrentCultureIgnoreCase));
            return result;
        }

        public List<City> GetCities()
        {
            var result = _cities.ToList();
            return result;
        }



    }
}