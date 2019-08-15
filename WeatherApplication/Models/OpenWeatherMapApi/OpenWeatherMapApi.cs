using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class OpenWeatherMapApi : IOpenWeatherMapApi
    {
        public async Task<OpenWeatherResponse> getDailyForecast(OpenWeatherParam param)
        {
            if (param == null)
            {
                return null;
            }

            var url = $"https://api.openweathermap.org/data/2.5/forecast?appid=77bea68862c21b7c9eb039c704002d81&q={param.City},{param.CountryCode}&units={param.Units}&lang={param.Language}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                
                var resultString = await response.Content.ReadAsStringAsync();

                var weatherResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(resultString);

                return weatherResponse;

            }
        }
    }
}