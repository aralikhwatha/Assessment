using InvoiceTracker.Application.Domain.Base;
using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;
using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Services.Invoice;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.CommandHandlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, BaseResponse<int>>
    {
        private readonly IInvoiceService _invoiceService;
        public CreateInvoiceHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<BaseResponse<int>> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();
            try
            {
                var invoice = MapInvoice(command);
                response.Payload = await _invoiceService.CreateInvoice(invoice);
                if (response.Payload > 0)
                {
                    response.Succcess = true;
                    response.Message = "Invoice Created Successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        private InvoiceDto MapInvoice(CreateInvoiceCommand command)
        {
            return new InvoiceDto
            {
                InvoiceStatusId = (int)InvoiceStatusEnum.Pending,
                IsDeleted = false,
                VendorId = command.VendorId,
                PaymentDate = command.PaymentDate,
                LineItems = MapInvoiceLineItems(command)


            };
        }

        private List<InvoiceLineItemDto> MapInvoiceLineItems(CreateInvoiceCommand command)
        {
            var results = new List<InvoiceLineItemDto>();
            if (command == null || command.LineItems == null)
                return results;
            foreach (var lineItem in command.LineItems)
                results.Add(new InvoiceLineItemDto
                {
                    Description = lineItem.Description,
                    IsDeleted = false,
                    Quantity = lineItem.Quantity,
                    UnitPrice = lineItem.UnitPrice,
                });

            return results;

        }
    }
}
