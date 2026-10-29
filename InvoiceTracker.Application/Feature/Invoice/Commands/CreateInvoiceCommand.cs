using InvoiceTracker.Application.Domain.Base;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.Commands
{
    public class CreateInvoiceCommand : IRequest<BaseResponse<int>>
    {
   
        public List<InvoiceLineItem>? LineItems { get; set; }
        public int InvoiceStatus { get; set; }
        public int VendorId { get; set; }
        public DateTime PaymentDate { get; set; }

    }

    public class InvoiceLineItem
    {
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }

    }
}
