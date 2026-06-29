using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;
using Faptecsolution.CaritasCRM.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Faptecsolution.CaritasCRM.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your persistence services here
            services.AddDbContext<CaritasCRMDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CaritasCRMConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IInvoicePaymentRepository, InvoicePaymentRepository>();
            services.AddScoped<IInvoiceProductRepository, InvoiceProductRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IQuoteProductRepository, QuoteProductRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            return services;
        }
    }
}
