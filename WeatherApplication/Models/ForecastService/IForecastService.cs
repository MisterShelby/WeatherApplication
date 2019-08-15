using System.Threading.Tasks;

namespace WeatherApplication.Models.ForecastService
{
    public interface IForecastService
    {
        Task<ForecastResultView> GetForecast(ForecastParam param);
    }
}
