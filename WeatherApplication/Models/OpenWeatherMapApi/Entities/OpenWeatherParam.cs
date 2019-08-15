namespace WeatherApplication.Models.OpenWeatherMapApi
{
    public class OpenWeatherParam
    {
        public string City { get; set; }

        public string CountryCode { get; set; }

        public string Units { get; set; } = "imperial";

        public string Language { get; set; } = "en_us";
    }
}