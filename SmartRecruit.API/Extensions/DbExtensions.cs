using Microsoft.EntityFrameworkCore;
using SmartRecruit.Infrastructure.Data;
using SmartRecruit.Infrastructure.Data.Interceptors;

namespace SmartRecruit.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<UpdateAuditInterceptor>();
            services.AddSingleton<SoftDeleteInterceptor>();
            
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var audit = sp.GetRequiredService<UpdateAuditInterceptor>();
                var softDelete = sp.GetRequiredService<SoftDeleteInterceptor>();
                options.UseSqlServer(configuration.GetConnectionString("MyCnn"))
                       .AddInterceptors(audit, softDelete);
            });
            
            return services;
        }
    }
}
