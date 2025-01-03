using InveonBootcamp.CompletionProject.Core.ExceptionHandler.ExceptionClasses;
using System.Net;

namespace InveonBootcamp.CompletionProject.Core.ExceptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError($"Bir hata oluştu: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string result;

            switch (exception)
            {
                case NotFoundException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message });
                    break;
                case CreationFailedException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message });
                    break;
                case UpdateFailedException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message });
                    break;
                case DeletionFailedException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message });
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = System.Text.Json.JsonSerializer.Serialize(new { error = "Internal Server Error from the custom middleware." });
                    break;
            }

            return context.Response.WriteAsync(result);
        }
    }
}