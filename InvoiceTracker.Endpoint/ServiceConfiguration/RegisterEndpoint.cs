using InvoiceTracker.Endpoint.Services;

namespace InvoiceTracker.Endpoint.ServiceConfiguration
{
    public static class RegisterEndpoint
    {
        public static void AddEndpoint(this IServiceCollection services)
        {
            services.AddHostedService<EscalationService>();
        }
    }
}
