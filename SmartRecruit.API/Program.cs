using Serilog;
using Hangfire;
using SmartRecruit.Extensions;
using SmartRecruit.Logging;
using SmartRecruit.Application;
using SmartRecruit.Infrastructure;

namespace SmartRecruit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Logging (Serilog)
            builder.Host.UseSerilog((context, configuration) =>
                configuration
                    .Enrich.With(new SensitiveDataEnricher())
                    .ReadFrom.Configuration(context.Configuration));

            // 2. Data & Infrastructure
            builder.Services.AddDbContextConfiguration(builder.Configuration);
            builder.Services.AddApplicationDI();
            builder.Services.AddInfrastructureDI(builder.Configuration);

            // 3. Security & Policy
            builder.Services.AddCorsConfiguration(builder.Configuration);
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddRateLimitingConfiguration(builder.Configuration);

            // 4. API Features
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                });

            builder.Services.AddSignalR();
            builder.Services.AddSwaggerConfiguration();

            // 5. Background Tasks
            builder.Services.AddHangfireConfiguration(builder.Configuration);

            // --- APP BUILD ---
            var app = builder.Build();

            // 6. HTTP Pipeline (Middleware)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseErrorHandling();
            app.UseRateLimiter();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            // 7. Background Job Scheduling
            app.UseHangfireDashboard();
            app.UseRecurringJobs();

            // 8. Endpoints
            app.MapControllers();
            app.MapAppHubs();

            app.Run();
        }
    }
}
