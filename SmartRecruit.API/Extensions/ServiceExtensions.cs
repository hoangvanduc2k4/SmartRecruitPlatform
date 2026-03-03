using SmartRecruit.Middlewares;

namespace SmartRecruit.Extensions
{
    public static class ServiceExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
