using InvoiceTracker.Application.Dtos;

namespace InvoiceTracker.Application.Services.Notification
{
    public interface INotificationService
    {
        Task SendNotification(SendNotificationParameterDto parameters);
    }
}
