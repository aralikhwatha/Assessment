namespace InvoiceTracker.Application.Services.Payment
{
    public interface IPaymentService
    {
        Task<bool> Pay(int reference, decimal amount);
    }
}
