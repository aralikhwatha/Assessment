namespace InvoiceTracker.Application.Dtos
{
    public class InvoiceLineItemDto
    {
        public int InvoiceLineItemId { get; set; }
        public int InvoiceId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
