using InvoiceTracker.Application.Domain.Base;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.Commands
{
    public class PayInvoiceCommand: IRequest<BaseResponse<int>>
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
    }
}
