namespace InvoiceTracker.Application.Dtos
{
    public class PaymentDto
    {
        public int ReferenceNumber { get; set; }
        public Decimal Amount { get; set; }
        public bool Proccesed { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
