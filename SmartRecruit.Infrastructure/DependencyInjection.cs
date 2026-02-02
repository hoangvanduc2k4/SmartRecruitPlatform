using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Repositories;

namespace SmartRecruit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            return services;
        }
    }
}
