using System.Web;
using System.Web.Mvc;
using WeatherApplication.Models.Filters;

namespace WeatherApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
