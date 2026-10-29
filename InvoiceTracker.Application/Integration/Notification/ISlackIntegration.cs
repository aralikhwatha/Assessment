namespace InvoiceTracker.Application.Integration.Notification
{
    public interface ISlackIntegration
    {
        Task SendSlackMessage(string toChannel, string message);
    }
}
