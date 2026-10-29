using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;

namespace InvoiceTracker.Application.Repository
{
    public interface IInvoiceRepository 
    {
        Task<int> CreateInvoiceAsync(InvoiceDto invoice);
        Task<InvoiceDto?> GetInvoiceAsync(int invoiceId);
        Task<List<UnpaidInvoiceDto>> GetUnpaidInvoicesAsync(List<int> invoiceStatusIds, int minNumberOfDay, int maxNumberOfDay);
        Task<List<EscalationRuleDto>> GetEscalationRulesAsync();
        Task<List<InvoiceEscalationGroupDto>> GetInvoiceEscalationGroupsAsync();
        Task<int> CreateInvoicePaymentEntryAsync(int invoiceId, decimal amount);
        Task<InvoicePaymentDto?> GetInvoicePaymentEntryAsync(int paymentEntryId);
        Task<List<InvoiceLineItemDto>> GetInvoiceLineItemsAsync(int invoiceId);
        Task UpdateInvoiceStateAsync(int invoiceId, InvoiceStatusEnum invoiceStatus);
    }
}
