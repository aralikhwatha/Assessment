using InvoiceTracker.Application.Domain.Base;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.Commands
{
    public class ProcessPaymentCommand: IRequest<BaseResponse<bool>>
    {
        public int PaymentReference { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Processed { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
