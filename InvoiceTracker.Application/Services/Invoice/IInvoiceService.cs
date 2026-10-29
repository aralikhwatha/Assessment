using InvoiceTracker.Application.Dtos;

namespace InvoiceTracker.Application.Services.Invoice
{
    public interface IInvoiceService
    {
        Task<int> CreateInvoice(InvoiceDto invoice);
        Task<InvoiceDto> GetInvoice(int id);
        Task SendInvoiceSLAReminders();
        Task<int> PayInvoice(int invoiceId, decimal amount);

        Task ProcessInvoicePayment(PaymentDto payment);
    }
}
