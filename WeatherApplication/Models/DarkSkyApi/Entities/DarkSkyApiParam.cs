namespace WeatherApplication.Models.DarkSkyApi
{
    public class DarkSkyApiParam
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Units { get; set; } = "us";

        public string Language { get; set; } = "en";
    }
}