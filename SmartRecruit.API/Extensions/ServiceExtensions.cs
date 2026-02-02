using SmartRecruit.API.Middlewares;

namespace SmartRecruit.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
