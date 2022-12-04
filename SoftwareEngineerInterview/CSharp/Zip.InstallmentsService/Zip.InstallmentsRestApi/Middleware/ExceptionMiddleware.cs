using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Zip.InstallmentsRestApi.Controllers;
using Newtonsoft.Json;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsRestApi.Middleware
{
    /// <summary>
    /// implemented a custom error handling middleware so standard exceptions that can be converted into a JSON response with the appropriate HTTP Status code.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger,RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _nextRequestDelegate(httpContext);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error,"Unexpected error occured: {0}", ex);
                await HandleExceptionAsync(httpContext);
            }

        }
        private Task HandleExceptionAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new Error(httpContext.Response.StatusCode.ToString(), "Internal server error!! Please contact Support Team")));
        }
    }
}
