using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using System.Reflection;

namespace SmartRecruit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IWalletService, WalletService>();
            return services;
        }
    }
}
