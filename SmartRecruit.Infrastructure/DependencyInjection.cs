using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Configurations;
using SmartRecruit.Infrastructure.Repositories;
using SmartRecruit.Infrastructure.Services;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.Configure<GeminiSettings>(configuration.GetSection("Gemini"));
            
            services.AddScoped<IUserService, UserService>(); // Added

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddHttpClient<IGeminiService, GeminiService>();
            return services;
        }
    }
}
