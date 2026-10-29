namespace InvoiceTracker.Application.Dtos
{
    public class UnpaidInvoiceDto
    {
        public int InvoiceId { get; set; }
        public int InvoiceStatusId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
