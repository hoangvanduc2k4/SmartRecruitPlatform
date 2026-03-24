using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace SmartRecruit.Extensions
{
    public static class RateLimitExtensions
    {
        public static IServiceCollection AddRateLimitingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var rateLimitSettings = configuration.GetSection("RateLimitSettings");

            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                // 1. STRICT
                var strict = rateLimitSettings.GetSection("Strict");
                options.AddFixedWindowLimiter("strict", opt =>
                {
                    opt.Window = TimeSpan.FromMinutes(strict.GetValue<int>("WindowMinutes"));
                    opt.PermitLimit = strict.GetValue<int>("PermitLimit");
                    opt.QueueLimit = 0;
                });

                // 2. HEAVY
                var heavy = rateLimitSettings.GetSection("Heavy");
                options.AddFixedWindowLimiter("heavy", opt =>
                {
                    opt.Window = TimeSpan.FromMinutes(heavy.GetValue<int>("WindowMinutes"));
                    opt.PermitLimit = heavy.GetValue<int>("PermitLimit");
                    opt.QueueLimit = 0;
                });

                // 3. DEFAULT
                var defaultPolicy = rateLimitSettings.GetSection("Default");
                options.AddFixedWindowLimiter("default", opt =>
                {
                    opt.Window = TimeSpan.FromMinutes(defaultPolicy.GetValue<int>("WindowMinutes"));
                    opt.PermitLimit = defaultPolicy.GetValue<int>("PermitLimit");
                    opt.QueueLimit = 0;
                });
            });

            return services;
        }
    }
}
