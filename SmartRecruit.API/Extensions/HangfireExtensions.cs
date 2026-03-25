using Hangfire;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Jobs;

namespace SmartRecruit.Extensions
{
    public static class HangfireExtensions
    {
        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("MyCnn")));

            services.AddHangfireServer(options => options.WorkerCount = 5);
            return services;
        }

        public static IApplicationBuilder UseRecurringJobs(this IApplicationBuilder app)
        {
            RecurringJob.AddOrUpdate<TokenCleanupJob>(
                "token-cleanup-daily",
                job => job.RunAsync(),
                Cron.Daily
            );

            RecurringJob.AddOrUpdate<IJobService>(
                "job-expiration-hourly",
                service => service.UpdateExpiredJobsAsync(),
                Cron.Hourly
            );
            return app;
        }
    }
}
