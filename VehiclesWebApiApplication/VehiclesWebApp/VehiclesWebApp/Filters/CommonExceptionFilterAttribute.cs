//File Name : CommonExceptionFilterAttribute.cs
//Author    : Mathan Vaithilingam
//Description : Exception filter

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;


namespace VechicleWebApp.Filters
{
    /// <summary>
    /// Common Exception interceptor for Web API
    /// </summary>
    public class CommonExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Override base exception implementation
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionType = actionExecutedContext.Exception.GetType();

            if (exceptionType == typeof(ValidationException))
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ValidationException", actionExecutedContext.Exception);
            }
            else if(exceptionType == typeof(InvalidOperationException))
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.NoContent, "InvalidOperationException", actionExecutedContext.Exception);
            }
            else if(exceptionType == typeof(DbUpdateConcurrencyException))
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Conflict, "DbUpdateConcurrencyException", actionExecutedContext.Exception);
            }
            else if(exceptionType == typeof(DbUpdateException))
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Conflict, "DbUpdateException", actionExecutedContext.Exception);
            }
            else if (exceptionType == typeof(DataException))
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Conflict, "DataException", actionExecutedContext.Exception);
            }
            else
            {
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception", actionExecutedContext.Exception);

            }

            base.OnException(actionExecutedContext);
        }
    }
}