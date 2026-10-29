using InvoiceTracker.Application.Integration.Notification;
using InvoiceTracker.Application.Integration.ServiceBus;
using InvoiceTracker.Integration.Noticatification;
using InvoiceTracker.Integration.ServiceBus;

namespace InvoiceTracker.Web.ServiceConfiguration
{
    public static class IntegrationServiceConfiguration
    {
        public static void AddIntegrationService(this IServiceCollection services)
        {
            services.AddTransient<IMessageBusIntegration, MessageBusIntegration>();
            services.AddTransient<IEmailIntegration, EmailIntegration>();
            services.AddTransient<ISlackIntegration, SlackIntegration>();

        }
    }
}
