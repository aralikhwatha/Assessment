using InvoiceTracker.Endpoint.Consumers;
using MassTransit;

namespace InvoiceTracker.Endpoint.ServiceConfiguration
{
    public static class ConsumerServiceConfiguration
    {
        public static void AddConsumerService(this IServiceCollection services, string rabbitmqServer, string username, string password, string queueName)
        {
            services.AddMassTransit(x=> 
            {
                x.AddConsumer<PaymentReceivedConsumer>();

                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri(rabbitmqServer), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                    config.ReceiveEndpoint(queueName, e =>
                    {
                        e.Consumer<PaymentReceivedConsumer>(context);
                    });
                   
                });

            });

        }
    }
}
