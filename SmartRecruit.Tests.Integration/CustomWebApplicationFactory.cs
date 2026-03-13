using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Infrastructure.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using SmartRecruit.API;
using SmartRecruit.Application.Interfaces.Services;
using Moq;
using Moq.Protected;
using Microsoft.Extensions.Configuration;
using SmartRecruit.Application.DTO.Job;

namespace SmartRecruit.Tests.Integration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private SqliteConnection? _connection;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "ConnectionStrings:MyCnn", "DataSource=:memory:" },
                    { "Jwt:Key", "SuperSecretKeyForIntegrationTesting123!" },
                    { "Jwt:Issuer", "SmartRecruit" },
                    { "Jwt:Audience", "SmartRecruit" },
                    { "PayOS:ClientId", "dummy" },
                    { "PayOS:ApiKey", "dummy" },
                    { "PayOS:ChecksumKey", "dummy" },
                    { "PayOS:SkipSignatureVerification", "true" },
                    { "Gemini:ApiKey", "dummy" },
                    { "Cloudinary:CloudName", "dummy" },
                    { "Cloudinary:ApiKey", "dummy" },
                    { "Cloudinary:ApiSecret", "dummy" }
                });
            });

            builder.ConfigureServices(services =>
            {
                // Remove existing DB context registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Create a single SQLite connection for the duration of the test run to keep in-memory DB alive
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(_connection);
                });

                // Mock external services to prevent side effects
                var emailServiceMock = new Mock<IEmailService>();
                services.AddSingleton(emailServiceMock.Object);

                var geminiServiceMock = new Mock<IGeminiService>();
                geminiServiceMock.Setup(x => x.CheckJobContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new JobScreeningResponse { IsSafe = true, Analysis = "Mocked success" });
                geminiServiceMock.Setup(x => x.ScoreCvAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new CvScreeningResponse { MatchScore = 85, SkillMatch = 80, ExperienceMatch = 90, AI_Summary = "Mocked AI summary" });
                services.AddSingleton(geminiServiceMock.Object);

                var cloudinaryServiceMock = new Mock<ICloudinaryService>();
                cloudinaryServiceMock.Setup(x => x.ManageFileAsync(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync("https://cloudinary.com/mock-url.png");
                services.AddSingleton(cloudinaryServiceMock.Object);

                // Mock Hangfire
                var hangfireMock = new Mock<Hangfire.IBackgroundJobClient>();
                services.AddSingleton(hangfireMock.Object);

                // Mock IHttpClientFactory for PayOS
                var handlerMock = new Mock<HttpMessageHandler>();
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(new
                    {
                        code = "00",
                        desc = "success",
                        data = new { status = "PAID" }
                    })
                };

                handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                    )
                    .ReturnsAsync(response);

                var httpClient = new HttpClient(handlerMock.Object);
                var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                httpClientFactoryMock.Setup(f => f.CreateClient("PayOS")).Returns(httpClient);
                services.AddSingleton(httpClientFactoryMock.Object);
            });

            builder.UseEnvironment("Testing");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
