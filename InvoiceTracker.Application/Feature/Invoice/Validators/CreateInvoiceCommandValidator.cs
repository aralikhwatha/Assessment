using FluentValidation;
using InvoiceTracker.Application.Feature.Invoice.Commands;

namespace InvoiceTracker.Application.Feature.Invoice.Validators
{
    public class CreateInvoiceCommandValidator: AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator() 
        {
            RuleFor(i => i.VendorId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(i => i.PaymentDate).NotEmpty().NotNull().GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
