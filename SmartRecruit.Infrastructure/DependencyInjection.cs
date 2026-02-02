using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using SmartRecruit.Infrastructure.Configurations;

namespace SmartRecruit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            return services;
        }
    }
}
