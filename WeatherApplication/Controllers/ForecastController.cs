using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherApplication.Models.ForecastService;

namespace WeatherApplication.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IForecastService _forecastService;

        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        // GET: Forecast
        [OutputCache(Duration = 60*60)]
        public async Task<string> GetForecast([FromUri] ForecastParam param)
        {
            if (param == null)
            {
                return null;
            }
            var result = await _forecastService.GetForecast(param);
            return JsonConvert.SerializeObject(result);
        }
    }
}