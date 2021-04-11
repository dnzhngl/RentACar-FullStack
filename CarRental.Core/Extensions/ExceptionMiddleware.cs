using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Extensions
{
    /// <summary>
    /// Handles the errors 
    /// </summary>
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Bütün kodları try catch içerisine alır. Hata oluşursa handlelar, oluşmazsa normal çalışır.
        /// <summary>
        /// It covers all of the codes with try catch code block. If an error occurs it handles, else run operations as expected.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        /// <summary>
        /// Handles exceptions. It executes when an exception occurs.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="e">Exception in a type of Exception</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json"; 
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";

            if (e.GetType() == typeof(ValidationException)) 
            { 
                // Validation errors
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = e.Message,
                    ValidationErrors = ((ValidationException)e).Errors
                }.ToString());
            }
            else if (e.GetType() == typeof(SecurityException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            return httpContext.Response.WriteAsync(new ErrorDetails // Sistematic errors
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }


        #region
        //private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        //{
        //    httpContext.Response.ContentType = "application/json";
        //    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        //    string message = "Internal Server Error";
        //    IEnumerable<ValidationFailure> errors;
        //    if (e.GetType() == typeof(ValidationException))
        //    {
        //        message = e.Message;
        //        errors = ((ValidationException)e).Errors;
        //        httpContext.Response.StatusCode = 400;

        //        // Validation errors
        //        return httpContext.Response.WriteAsync(new ValidationErrorDetails
        //        {
        //            StatusCode = 400,
        //            Message = message,
        //            ValidationErrors = errors
        //        }.ToString());
        //    }

        //    return httpContext.Response.WriteAsync(new ErrorDetails // Sistematic errors
        //    {
        //        StatusCode = httpContext.Response.StatusCode,
        //        Message = message
        //    }.ToString());
        //}
        #endregion
    }
}
