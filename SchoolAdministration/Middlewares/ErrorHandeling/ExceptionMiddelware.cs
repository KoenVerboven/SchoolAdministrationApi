
using System.Net;
using System.Text.Json;

namespace SchoolAdministration.Middlewares.ErrorHandeling
{
    public class ExceptionMiddelware(IHostEnvironment environment, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)//the name must be InvokeAsync, else it won't work!
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, environment);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment environment)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = environment.IsDevelopment()
                ? new ApiErrorResponse(statusCode: context.Response.StatusCode,message: exception.Message,details: exception.StackTrace?.ToString())
                : new ApiErrorResponse(statusCode: context.Response.StatusCode,message: "Internal Server Error",details: exception.Message);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            return context.Response.WriteAsync(json);
        }
    };
}
