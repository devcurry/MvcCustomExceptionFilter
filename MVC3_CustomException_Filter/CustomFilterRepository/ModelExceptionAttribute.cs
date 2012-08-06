using System.Data;
using System.Web.Mvc;
using MVC3_CustomException_Filter.Models;
namespace MVC3_CustomException_Filter.CustomFilterRepository
{
    /// <summary>
    /// Class used to Handle the Exception for 
    /// Duplicate Entry For Primary Key
    /// This Handles System.Data.UpdateException
    /// </summary>
    public  class ModelExceptionAttribute : FilterAttribute,IExceptionFilter
    {
        public  void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is UpdateException)
            {

                var routeData = filterContext.RouteData;
                 var controllerName =  routeData.Values["controller"].ToString();
                var actionName = routeData.Values["action"].ToString() ;

                filterContext.Result = new RedirectResult("~/ErrorPages/" + controllerName + "_" + actionName + ".html");

                filterContext.ExceptionHandled = true;
            }
        }
    }
}