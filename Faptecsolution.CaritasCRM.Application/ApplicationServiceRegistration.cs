using Microsoft.Extensions.DependencyInjection;

namespace Faptecsolution.CaritasCRM.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddAutoMapper(cfg => { }, typeof(ApplicationServiceRegistration).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));  
            return services;
        }
    }
}
