using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApplication.Models.DarkSkyApi
{
    public class DarkSkyApi : IDarkSkyApi
    {
        public async Task<DarkSkyResponse> GetForecast(DarkSkyApiParam param)
        {
            if (param.Latitude == default && param.Longitude == default)
            {
                return null;
            }

            var url = $"https://api.darksky.net/forecast/afb07fd1640071767e85dd1c42de6cc8/{param.Latitude},{param.Longitude}?lang={param.Language}&units={param.Units}&exclude=currently,minutely,daily,alerts,flags";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var resultString = await response.Content.ReadAsStringAsync();

                var darkSkyResponse = JsonConvert.DeserializeObject<DarkSkyResponse>(resultString);

                return darkSkyResponse;

            }
        }
    }
}