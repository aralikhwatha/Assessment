using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Endpoint.Services;
using InvoiceTracker.MessageContract;
using MassTransit;
using MediatR;
using System.Threading;

namespace InvoiceTracker.Endpoint.Consumers
{
    public class PaymentReceivedConsumer : IConsumer<PaymentReceived>
    {
        private readonly ILogger<PaymentReceivedConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;
        public PaymentReceivedConsumer(ILogger<PaymentReceivedConsumer> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task Consume(ConsumeContext<PaymentReceived> context)
        {
            var message = context.Message;
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(
                    new ProcessPaymentCommand
                    {
                        Amount = message.Amount,
                        ErrorMessage = message.ErrorMessage,
                        PaymentReference = message.ReferenceNumber,
                        CreatedAt = message.CreatedAt,
                        Processed = message.Proccesed
                    }, context.CancellationToken);
            }
        }
    }
}
