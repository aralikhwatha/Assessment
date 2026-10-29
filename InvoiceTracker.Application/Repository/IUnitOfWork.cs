namespace InvoiceTracker.Application.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IInvoiceRepository Invoices { get; }
    }
}
