using InvoiceTracker.Application.Dtos;

namespace InvoiceTracker.Application.Services.Invoice.InvoiceEscalation
{
    public interface IInvoiceEscalator
    {
        Task Escalate(InvoiceEscalationParameterDto parameters);
    }
}
