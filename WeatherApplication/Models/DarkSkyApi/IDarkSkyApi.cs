using System.Threading.Tasks;

namespace WeatherApplication.Models.DarkSkyApi
{
    public interface IDarkSkyApi
    {
        Task<DarkSkyResponse> GetForecast(DarkSkyApiParam param);

    }
}
