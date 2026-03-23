
using WebPortal.Services;
using WebPortal.Services.Api;

namespace SmartRecruitWeb.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebPortalServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register IHttpContextAccessor for TokenService
            services.AddHttpContextAccessor();

            // Register Token Service & Auth Handler
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<JwtAuthHandler>();

            // Configure Base API URL
            var apiBaseUrl = configuration.GetValue<string>("ApiBaseUrl") ?? "http://localhost:5000/api/";

            if (!apiBaseUrl.EndsWith("/"))
            {
                apiBaseUrl += "/";
            }

            // Register API Services with HttpClient and JwtAuthHandler
            services.AddHttpClient<IAuthApiService, AuthApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            services.AddHttpClient<IJobApiService, JobApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            services.AddHttpClient<IApplicationApiService, ApplicationApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            services.AddHttpClient<IWalletApiService, WalletApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            services.AddHttpClient<IAdminApiService, AdminApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            services.AddHttpClient<ICategoryApiService, CategoryApiService>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtAuthHandler>();

            // Register Mock Data Service as a Singleton so all pages share the same mock data instance
            services.AddSingleton<IMockDataService, MockDataService>();

            return services;
        }
    }
}
