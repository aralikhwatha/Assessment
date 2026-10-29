using InvoiceTracker.Web.Middleware;

namespace InvoiceTracker.Web.ServiceConfiguration
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
