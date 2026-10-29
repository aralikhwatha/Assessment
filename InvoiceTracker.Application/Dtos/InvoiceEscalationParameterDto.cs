namespace InvoiceTracker.Application.Dtos
{
    public class InvoiceEscalationParameterDto
    {
        public List<EscalationRuleDto>? EscalationRules { get; set; }
        public List<InvoiceEscalationGroupDto>? EscalationGroups { get; set; }
    }
}
