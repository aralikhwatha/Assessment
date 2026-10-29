using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Feature.Payment.Commands;
using InvoiceTracker.Application.Services.Invoice;
using InvoiceTracker.Application.Services.Notification;
using InvoiceTracker.Application.Services.Payment;
using InvoiceTracker.MessageContract;
using MassTransit;

namespace InvoiceTracker.Web.ServiceConfiguration
{
    public static class ApplicationServiceConfiguration
    {
        public static void AddApplicationService(this IServiceCollection services, string rabbitmqServer, string username, string password)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateInvoiceCommand).Assembly, typeof(CreatePaymentCommand).Assembly));
            services.AddTransient<IInvoiceService,InvoiceService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    
                    config.Host(new Uri(rabbitmqServer), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                   
                });
            });

        }
    }
}
