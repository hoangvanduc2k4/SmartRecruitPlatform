
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartRecruit.Extensions;
using SmartRecruit.Logging;
using SmartRecruit.Application;
using SmartRecruit.Infrastructure;
using SmartRecruit.Infrastructure.Data;
using SmartRecruit.Infrastructure.Data.Interceptors;
using SmartRecruit.Infrastructure.Jobs;

namespace SmartRecruit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog
            builder.Host.UseSerilog((context, configuration) =>
                configuration
                    .Enrich.With(new SensitiveDataEnricher())
                    .ReadFrom.Configuration(context.Configuration));

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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                });
            
            // JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SmartRecruit API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.\r\n\r\nExample: '12345abcdef'",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });


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

          
            app.UseErrorHandlingMiddleware();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();


            // Hangfire Dashboard
            app.UseHangfireDashboard();

                RecurringJob.AddOrUpdate<TokenCleanupJob>(
                "token-cleanup-daily",
                job => job.RunAsync(),
                Cron.Daily
            );

            app.MapControllers();

            app.Run();
        }
    }
}
