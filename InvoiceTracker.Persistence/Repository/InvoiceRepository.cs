using Dapper;
using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;
using InvoiceTracker.Application.Repository;
using InvoiceTracker.Persistence.Context;

namespace InvoiceTracker.Persistence.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private string _loggedOnUser = "aralikhwatha";
        private readonly DbContext _dbContext;
        public InvoiceRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateInvoiceAsync(InvoiceDto invoice)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                var invoiceId = await connection.ExecuteScalarAsync<int>(DatabaseConstant.CreateInvoiceSql,
                       new
                       {
                           InvoiceStatusId = invoice.InvoiceStatusId,
                           VendorId = invoice.VendorId,
                           PaymentDate = invoice.PaymentDate,
                           CreatedBy = _loggedOnUser,
                           CreatedDate = DateTime.UtcNow,
                           ModifiedBy = _loggedOnUser,
                           ModifiedDate = DateTime.UtcNow,
                           IsDeleted = false,
                       });

                var lineItems = MapInvoiceIdIntoInvoiceItems(invoiceId, invoice);
                await connection.ExecuteAsync(DatabaseConstant.CreateInvoiceLineItemSql, invoice.LineItems);
                await connection.ExecuteAsync(DatabaseConstant.CreateInvoiceTransactionSql,
                    new
                    {
                        TransactionTypeId = TransactionTypeEnum.Invoice,
                        AccountingTypeId = AccountingTypeEnum.Debit,
                        InvoiceId = invoiceId,
                        CreatedBy = _loggedOnUser,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = _loggedOnUser,
                        ModifiedDate = DateTime.UtcNow,
                        IsDeleted = false,

                    });

                return invoiceId;

            }
        }

        public async Task<List<EscalationRuleDto>> GetEscalationRulesAsync()
        {
            var results = new List<EscalationRuleDto>();
            using (var connection = _dbContext.CreateConnection())
            {
                var rules = await connection.QueryAsync<EscalationRuleDto>(DatabaseConstant.GetInvoiceEscalationRulesSql);

                if (rules != null && rules.Count() > 0)
                    results = rules.AsList();
            }

            return results;
        }

        public async Task<List<InvoiceEscalationGroupDto>> GetInvoiceEscalationGroupsAsync()
        {
            var results = new List<InvoiceEscalationGroupDto>();
            using (var connection = _dbContext.CreateConnection())
            {
                var escalationGroups = await connection.QueryAsync<InvoiceEscalationGroupDto>(DatabaseConstant.GetInvoiceEscalationGroupsSql); //this can be cached

                if (escalationGroups != null && escalationGroups.Count() > 0)
                    results = escalationGroups.AsList();
            }
            return results;
        }

        public async Task<List<UnpaidInvoiceDto>> GetUnpaidInvoicesAsync()
        {
            var results = new List<UnpaidInvoiceDto>();
            using (var connection = _dbContext.CreateConnection())
            {
                var invoices = await connection.QueryAsync<UnpaidInvoiceDto>(DatabaseConstant.GetUnpaidInvoicesSql);

                if (invoices != null && invoices.Any())
                    results = invoices.AsList();
            }

            return results;
        }

        public async Task<List<UnpaidInvoiceDto>> GetUnpaidInvoicesAsync(List<int> invoiceStatusIds, int minNumberOfDays, int maxNumberOfDays)
        {
            var results = new List<UnpaidInvoiceDto>();
            using (var connection = _dbContext.CreateConnection())
            {
                var invoices = await connection.QueryAsync<UnpaidInvoiceDto>(DatabaseConstant.GetUnpaidInvoicesSql,
                    new
                    {
                        invoiceStatusIds = invoiceStatusIds,
                        minNumberOfDays = minNumberOfDays,
                        maxNumberOfDays = maxNumberOfDays
                    });

                if (invoices != null && invoices.Count() > 0)
                    results = invoices.AsList();
            }

            return results;
        }

        public async Task<int> CreateInvoicePaymentEntryAsync(int invoiceId, decimal amount)
        {

            using (var connection = _dbContext.CreateConnection())
            {

                return await connection.ExecuteScalarAsync<int>(DatabaseConstant.CreateInvoicePaymentEntrySql,
                       new
                       {
                           InvoiceId = invoiceId,
                           Amount = amount,
                           CreatedBy = _loggedOnUser,
                           CreatedDate = DateTime.UtcNow,
                           IsDeleted = false,
                       });


            }
        }

        public async Task<InvoiceDto?> GetInvoiceAsync(int invoiceId)
        {

            using (var connection = _dbContext.CreateConnection())
            {
                var invoices = await connection.QueryAsync<InvoiceDto>(DatabaseConstant.GetInvoiceSql,
                    new
                    {
                        invoiceId = invoiceId
                    });

                if (invoices != null && invoices.Count() > 0)
                    return invoices.AsList().First();
            }

            return null;

        }

        private List<InvoiceLineItemDto> MapInvoiceIdIntoInvoiceItems(int invoiceId, InvoiceDto invoice)
        {
            var results = new List<InvoiceLineItemDto>();
            if (invoice == null || invoice.LineItems == null)
                return results;

            foreach (var item in invoice.LineItems)
            {
                item.InvoiceId = invoiceId;
                results.Add(item);
            }

            return results;
        }

        public async Task<InvoicePaymentDto?> GetInvoicePaymentEntryAsync(int paymentEntryId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var paymentEntry = await connection.QueryAsync<InvoicePaymentDto>(DatabaseConstant.GetInvoicePaymentEntrySql,
                    new
                    {
                        paymententryId = paymentEntryId
                    });

                if (paymentEntry != null && paymentEntry.Count() > 0)
                    return paymentEntry.AsList().First();
            }

            return null;
        }

        public async Task<List<InvoiceLineItemDto>> GetInvoiceLineItemsAsync(int invoiceId)
        {
            var results = new List<InvoiceLineItemDto>();
            using (var connection = _dbContext.CreateConnection())
            {
                var invoiceLineItems = await connection.QueryAsync<InvoiceLineItemDto>(DatabaseConstant.GetInvoiceLineItemsSql,
                    new
                    {
                        invoiceId = invoiceId
                    });

                if (invoiceLineItems != null && invoiceLineItems.Count() > 0)
                    results = invoiceLineItems.AsList();
            }

            return results;
        }

        public async Task UpdateInvoiceStateAsync(int invoiceId, InvoiceStatusEnum invoiceStatus)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                await connection.ExecuteAsync(DatabaseConstant.UpdateInvoiceStatusSql,
                          new
                          {
                              InvoiceId = invoiceId,
                              ModifiedBy = _loggedOnUser,
                              ModifiedDate = DateTime.UtcNow,
                              InvoiceStatusId = (int)invoiceStatus
                          });


            }
        }
    }
}
