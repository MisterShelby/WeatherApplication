using Moq;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using WeatherApplication.Models.CityService;
using WeatherApplication.Models.DarkSkyApi;
using WeatherApplication.Models.ForecastService;
using WeatherApplication.Models.OpenWeatherMapApi;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WeatherApplication.Tests.Services
{
    public class ForecastServiceTests
   {
       private readonly Mock<IOpenWeatherMapApi> _openWeatherApi;
       private readonly Mock<IDarkSkyApi> _darkSkyApi;
       private readonly Mock<ICityService> _cityService;
       private readonly IForecastService _forecastService;
       private readonly ForecastParam _param;

       public ForecastServiceTests()
       {
           _openWeatherApi = new Mock<IOpenWeatherMapApi>();
           _darkSkyApi = new Mock<IDarkSkyApi>();
           _cityService = new Mock<ICityService>();
           _param = getForecastParam();

           _forecastService = new ForecastService(_openWeatherApi.Object,_darkSkyApi.Object,_cityService.Object);
       }

       [Fact]
       public async void GetForecast_CityIsNull_Null()
       {
           //arrange
           var param = getForecastParam();
           _cityService.Setup(x => x.GeCityByName(It.IsAny<string>())).Returns((Models.ForecastService.City)null);
           //act
           var result = await _forecastService.GetForecast(param);

           //assert
           Assert.IsNull(result);
       }

       [Fact]
       public async void GetForecast_DarkSkyResponseIsNotNull_Success()
       {
            //arrange
            var param = _param;
            var response = getDarkSkyResponse();
            _darkSkyApi.Setup(x => x.GetForecast(It.IsAny<DarkSkyApiParam>()))
                .Returns(Task.FromResult(response));
            //act
            var result = await _forecastService.GetForecast(param);
            //assert
       }

       [Fact]
       public async void GetForecast_DarkSkyResponseIsNull()
       {
            //arrange
            var param = _param;
            _darkSkyApi.Setup(x => x.GetForecast(It.IsAny<DarkSkyApiParam>()))
                .Returns(Task.FromResult((DarkSkyResponse)null));
            //act
            var result = await _forecastService.GetForecast(param);
            //assrt
       }

       private DarkSkyResponse getDarkSkyResponse()
       {
           var filler = new Filler<DarkSkyResponse>();
           return filler.Create();
       }



       private ForecastParam getForecastParam()
       {
           var filler = new Filler<ForecastParam>();
           return filler.Create();
       }


   }
}
