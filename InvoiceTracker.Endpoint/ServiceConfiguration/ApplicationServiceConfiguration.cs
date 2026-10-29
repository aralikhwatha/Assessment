using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Feature.Payment.Commands;
using InvoiceTracker.Application.Services.Invoice;
using InvoiceTracker.Application.Services.Notification;
using InvoiceTracker.Application.Services.Payment;

namespace InvoiceTracker.Endpoint.ServiceConfiguration
{
    public static class ApplicationServiceConfiguration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly,typeof(SendEscalationNotificationCommand).Assembly));
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IPaymentService, PaymentService>();

        }
    }
}
