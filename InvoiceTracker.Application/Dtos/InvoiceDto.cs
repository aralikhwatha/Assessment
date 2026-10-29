namespace InvoiceTracker.Application.Dtos
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int VendorId { get; set; }
        public List<InvoiceLineItemDto>? LineItems { get; set; }
        public int InvoiceStatusId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
