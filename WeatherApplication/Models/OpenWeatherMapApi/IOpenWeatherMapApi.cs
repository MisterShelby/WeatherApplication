using System.Threading.Tasks;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public  interface IOpenWeatherMapApi
   {
       Task<OpenWeatherResponse> getDailyForecast(OpenWeatherParam param);

   }
}
