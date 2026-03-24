using SmartRecruit.Infrastructure.Hubs;
using SmartRecruit.Middlewares;

namespace SmartRecruit.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void MapAppHubs(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<NotificationHub>("/notificationHub");
        }
    }
}
