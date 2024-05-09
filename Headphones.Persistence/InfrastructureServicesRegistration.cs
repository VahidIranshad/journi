using Headphones.Application.Contracts;
using Headphones.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Headphones.Persistence
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryForJson<>));
            services.AddScoped<IHeadphoneRepository, HeadphoneRepository>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));



            return services;
        }
    }
}
