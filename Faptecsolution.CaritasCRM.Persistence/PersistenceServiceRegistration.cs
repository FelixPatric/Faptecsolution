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
            return services;
        }
    }
}
