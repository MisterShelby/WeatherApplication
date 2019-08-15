using System;
using System.Web.Mvc;

namespace WeatherApplication.Models.Filters
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {


                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now
                };

                addToDatabase(logger);

                filterContext.ExceptionHandled = true;
            }
        }

        private  void addToDatabase(ExceptionLogger logger)
        {

        }
    }
}