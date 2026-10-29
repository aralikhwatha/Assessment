namespace InvoiceTracker.Application.Dtos
{
    public class InvoicePaymentDto
    {
        public int InvoicePaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal  Amount { get; set; }
    }
}
