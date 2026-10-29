namespace InvoiceTracker.Application.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountingTypeId { get; set; }
        public int? InvoiceId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
