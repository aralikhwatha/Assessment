using InvoiceTracker.Application.Domain.Base;
using System.Text.Json;


namespace InvoiceTracker.Web.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object> { Message = $"Error: {ex.Message}", Succcess=false });
            }
        }
    }
}
