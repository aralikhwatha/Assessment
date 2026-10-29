namespace InvoiceTracker.Application.Dtos
{
    public class EscalationRuleDto
    {
        public int InvoiceStatusId { get; set; }
        public int MinNumberOfDays { get; set; }
        public int MaxNumberOfDays { get; set; }
        public int EscalationGroupId { get; set; }
    }
}
