
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Data;
using SmartRecruit.Infrastructure.Data.Interceptors;
using SmartRecruit.Infrastructure.Repositories;
using SmartRecruit.API.Extensions;
using SmartRecruit.Application;
using SmartRecruit.Infrastructure;

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


            app.MapControllers();

            app.Run();
        }
    }
}
