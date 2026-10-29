
using InvoiceTracker.Application.Integration.ServiceBus;
using InvoiceTracker.MessageContract;

namespace InvoiceTracker.Application.Services.Payment
{
    public class PaymentService : IPaymentService
    {

        private readonly IMessageBusIntegration _messageBusIntegration;
        public PaymentService(IMessageBusIntegration messageBusIntegration)
        {
            _messageBusIntegration = messageBusIntegration;
        }
        public async Task<bool> Pay(int reference, decimal amount)
        {

            //create a payment successfully

            await _messageBusIntegration.Send<PaymentReceived>(new PaymentReceived
            {
                CreatedAt = DateTime.UtcNow,
                Amount = amount,
                Proccesed = true,
                ReferenceNumber = reference
            });
            return true;
        }
    }
}
