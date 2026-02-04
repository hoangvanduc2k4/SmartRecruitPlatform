
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.API.Extensions;
using SmartRecruit.Application;
using SmartRecruit.Infrastructure;
using SmartRecruit.Infrastructure.Data;
using SmartRecruit.Infrastructure.Data.Interceptors;

namespace SmartRecruit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<UpdateAuditInterceptor>();
            builder.Services.AddSingleton<SoftDeleteInterceptor>();
            builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var audit = sp.GetRequiredService<UpdateAuditInterceptor>();
                var softDelete = sp.GetRequiredService<SoftDeleteInterceptor>();

                options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn"))
                       .AddInterceptors(audit, softDelete);
            });

            builder.Services.AddApplicationDI();
            builder.Services.AddInfrastructureDI(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Hangfire services.
            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(builder.Configuration.GetConnectionString("MyCnn"), new Hangfire.SqlServer.SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                    PrepareSchemaIfNecessary = true
                }));

            // Add the Hangfire server with limited workers
            builder.Services.AddHangfireServer(options =>
            {
                options.WorkerCount = 5;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseErrorHandlingMiddleware();

            app.UseAuthorization();

            // Hangfire Dashboard
            app.UseHangfireDashboard();


            app.MapControllers();

            app.Run();
        }
    }
}
