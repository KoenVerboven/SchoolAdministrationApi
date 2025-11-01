
using System.Net;
using System.Text.Json;

namespace SchoolAdministration.Middlewares.ErrorHandeling
{
    public class ExceptionMiddelware(IHostEnvironment environment, RequestDelegate requestDelegate)
    {
        public async Task InvokeAsync(HttpContext context)//the name must be InvokeAsync, else it won't work!
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, environment);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostEnvironment environment)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = environment.IsDevelopment()
                ? new ApiErrorResponse(statusCode: context.Response.StatusCode,message: ex.Message,details: ex.StackTrace?.ToString())
                : new ApiErrorResponse(statusCode: context.Response.StatusCode,message: "Internal Server Error",details: ex.Message);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase  };

            var json = System.Text.Json.JsonSerializer.Serialize(response, options);

            return context.Response.WriteAsync(json);
        }
    };
}
