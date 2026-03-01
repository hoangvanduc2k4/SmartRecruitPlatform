var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register IHttpContextAccessor for TokenService
builder.Services.AddHttpContextAccessor();

// Register Token Service & Auth Handler
builder.Services.AddScoped<SmartRecruitWeb.Services.Api.ITokenService, SmartRecruitWeb.Services.Api.TokenService>();
builder.Services.AddTransient<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

// Configure Base API URL
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "http://localhost:5000/api/";

// Register API Services with HttpClient and JwtAuthHandler
builder.Services.AddHttpClient<SmartRecruitWeb.Services.Api.IAuthApiService, SmartRecruitWeb.Services.Api.AuthApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

builder.Services.AddHttpClient<SmartRecruitWeb.Services.Api.IJobApiService, SmartRecruitWeb.Services.Api.JobApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

builder.Services.AddHttpClient<SmartRecruitWeb.Services.Api.IApplicationApiService, SmartRecruitWeb.Services.Api.ApplicationApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

builder.Services.AddHttpClient<SmartRecruitWeb.Services.Api.IWalletApiService, SmartRecruitWeb.Services.Api.WalletApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

builder.Services.AddHttpClient<SmartRecruitWeb.Services.Api.IAdminApiService, SmartRecruitWeb.Services.Api.AdminApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<SmartRecruitWeb.Services.Api.JwtAuthHandler>();

// Register Mock Data Service as a Singleton so all pages share the same mock data instance
builder.Services.AddSingleton<SmartRecruitWeb.Services.IMockDataService, SmartRecruitWeb.Services.MockDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
