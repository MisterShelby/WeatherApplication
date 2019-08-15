using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WeatherApplication.Models.CityService;
using WeatherApplication.Models.DarkSkyApi;
using WeatherApplication.Models.ForecastService;
using WeatherApplication.Models.OpenWeatherMapApi;

namespace WeatherApplication.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICityService>().To<CityService>();
            Bind<IDarkSkyApi>().To<DarkSkyApi>();
            Bind<IOpenWeatherMapApi>().To<OpenWeatherMapApi>();
            Bind<IForecastService>().To<ForecastService>();
        }
    }
}