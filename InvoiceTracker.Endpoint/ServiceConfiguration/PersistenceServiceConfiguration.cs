using InvoiceTracker.Application.Repository;
using InvoiceTracker.Persistence.Context;
using InvoiceTracker.Persistence.Repository;

namespace InvoiceTracker.Endpoint.ServiceConfiguration
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DbContext>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
