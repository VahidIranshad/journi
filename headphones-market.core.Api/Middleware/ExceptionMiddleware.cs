﻿using Newtonsoft.Json;
using System.Net;

namespace headphones_market.core.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            int num = 0;
            var x = num.ToString().Select(p => new { x = (int)p }).ToList().Sum(p => p.x);
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result = JsonConvert.SerializeObject(new ErrorDeatils
            {
                ErrorMessage = exception.Message,
                ErrorType = "Failure"
            });

            switch (exception)
            {

                case Microsoft.EntityFrameworkCore.DbUpdateException:
                    result = exception.InnerException.Message;
                    statusCode = HttpStatusCode.Conflict;
                    break;
                default:
                    result = exception.Message;
                    statusCode = HttpStatusCode.Conflict;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    public class ErrorDeatils
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
