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
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>(); // Added
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ITokenService, TokenService>();
            services.Configure<PayOSSettings>(configuration.GetSection("PayOS"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAILogRepository, AILogRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddHttpClient("PayOS", (sp, client) =>
            {
                var settings = configuration.GetSection("PayOS");
                client.DefaultRequestHeaders.Add("x-client-id", settings["ClientId"]);
                client.DefaultRequestHeaders.Add("x-api-key", settings["ApiKey"]);
            });

            services.AddHttpClient<IGeminiService, GeminiService>();
            return services;
        }
    }
}
