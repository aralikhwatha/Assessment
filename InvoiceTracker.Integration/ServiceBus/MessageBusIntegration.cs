using InvoiceTracker.Application.Integration.ServiceBus;
using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace InvoiceTracker.Integration.ServiceBus
{
    public class MessageBusIntegration : IMessageBusIntegration
    {
        private readonly ILogger<MessageBusIntegration> _logger;
        private readonly IPublishEndpoint _publishEndPoint;
        public MessageBusIntegration(ILogger<MessageBusIntegration> logger, IPublishEndpoint publishEndPoint)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }
        public async Task Send<T>(T message)
        {
            await _publishEndPoint.Publish(message, new CancellationToken());
        }
    }
}
