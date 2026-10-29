using InvoiceTracker.Application.Repository;

namespace InvoiceTracker.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInvoiceRepository Invoices { get; }
        public UnitOfWork(IInvoiceRepository invoices)
        {
            Invoices = invoices;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
