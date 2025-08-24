using Microsoft.AspNetCore.Diagnostics;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MachinesTelemetry.Api.Middlewears
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var traceId = httpContext.TraceIdentifier;

            _logger.LogError(exception, "Error occurred. TraceId: {TraceId}", traceId);

            var (statusCode, title) = MapException(exception);

            var extensions = new Dictionary<string, object?>(exception.Data.Count + 1)
            {
                { "traceId", traceId }
            };

            foreach (DictionaryEntry item in exception.Data)
            {
                extensions[item.Key?.ToString() ?? "unknown"] = item.Value;
            }

            await Results.Problem(
                title: title,
                statusCode: statusCode,
                extensions: extensions
            ).ExecuteAsync(httpContext);
        }

        private static (int StatusCode, string Title) MapException(Exception exception)
        {
            return exception switch
            {
                ValidationException => (StatusCodes.Status400BadRequest, exception.Message),
                InvalidOperationException => (StatusCodes.Status400BadRequest, exception.Message),
                KeyNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                _ => (StatusCodes.Status500InternalServerError,
                      Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production"
                          ? exception.Message
                          : "InternalServerError")
            };
        }
    }

}
