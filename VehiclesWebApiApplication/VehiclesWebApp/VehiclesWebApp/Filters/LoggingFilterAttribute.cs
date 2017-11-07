//File Name : LoggingFilterAttribute.cs
//Author    : Mathan Vaithilingam
//Description : Logging filter

using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using VechicleWebApp.Helpers;

namespace VechicleWebApp.Filters
{
    /// <summary>
    /// Common Logging interceptor for Web API
    /// </summary>
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Override base implementation of OnActionExecuting
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLoggerHelper());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Info(filterContext.Request, "Controller : " + filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.ActionName, "JSON", filterContext.ActionArguments);
        }
    }
}