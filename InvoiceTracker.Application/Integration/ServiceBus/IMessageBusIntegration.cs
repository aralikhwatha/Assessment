namespace InvoiceTracker.Application.Integration.ServiceBus
{
    public interface IMessageBusIntegration
    {
        Task Send<T>(T message);
    }
}
