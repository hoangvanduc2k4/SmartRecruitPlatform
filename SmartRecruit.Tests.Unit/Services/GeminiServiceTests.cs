using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Configurations;
using SmartRecruit.Infrastructure.Services;
using System.Net;
using System.Text;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class GeminiServiceTests
    {
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly Mock<ILogger<GeminiService>> _loggerMock;
        private readonly Mock<IAILogRepository> _aiLogRepoMock;
        private readonly IOptions<GeminiSettings> _config;
        private readonly GeminiService _service;

        public GeminiServiceTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>();
            _loggerMock = new Mock<ILogger<GeminiService>>();
            _aiLogRepoMock = new Mock<IAILogRepository>();

            var settings = new GeminiSettings
            {
                ApiKey = "test-key",
                Url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent"
            };
            _config = Options.Create(settings);

            var httpClient = new HttpClient(_handlerMock.Object);
            _service = new GeminiService(httpClient, _config, _loggerMock.Object, _aiLogRepoMock.Object);
        }

        [Fact]
        public async Task CheckJobContentAsync_ShouldReturnResponse_WhenAISucceeds()
        {
            // Arrange
            var mockResponseJson = new
            {
                candidates = new[]
                {
                    new
                    {
                        content = new
                        {
                            parts = new[]
                            {
                                new { text = "{\"IsSafe\": true, \"RiskLevel\": \"Low\", \"ViolationType\": \"None\", \"Analysis\": \"Job is safe.\"}" }
                            }
                        }
                    }
                }
            };

            SetupMockResponse(JsonConvert.SerializeObject(mockResponseJson));

            // Act
            var result = await _service.CheckJobContentAsync("Test Job", "Test Description");

            // Assert
            result.Should().NotBeNull();
            result.IsSafe.Should().BeTrue();
            result.RiskLevel.Should().Be("Low");
            result.Analysis.Should().Be("Job is safe.");
        }

        [Fact]
        public async Task CheckJobContentAsync_ShouldThrowException_WhenAIReturnsInvalidJson()
        {
            // Arrange
            var mockResponseJson = new
            {
                candidates = new[]
                {
                    new
                    {
                        content = new
                        {
                            parts = new[]
                            {
                                new { text = "This is not JSON" }
                            }
                        }
                    }
                }
            };

            SetupMockResponse(JsonConvert.SerializeObject(mockResponseJson));

            // Act
            Func<Task> act = async () => await _service.CheckJobContentAsync("Test Job", "Test Description");

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Invalid JSON format*");
        }

        [Fact]
        public async Task ScoreCvAsync_ShouldReturnScore_WhenAISucceeds()
        {
            // Arrange
            var mockResponseJson = new
            {
                candidates = new[]
                {
                    new
                    {
                        content = new
                        {
                            parts = new[]
                            {
                                new { text = "{\"MatchScore\": 85.5, \"SkillMatch\": 90.0, \"ExperienceMatch\": 80.0, \"AI_Summary\": \"Good fit\", \"MissingSkills\": [\"Docker\"], \"Recommendation\": \"Hire\"}" }
                            }
                        }
                    }
                }
            };

            SetupMockResponse(JsonConvert.SerializeObject(mockResponseJson));

            // Act
            var result = await _service.ScoreCvAsync("CV Content", "JD Content");

            // Assert
            result.Should().NotBeNull();
            result.MatchScore.Should().Be(85.5m);
            result.MissingSkills.Should().Contain("Docker");
        }

        [Fact]
        public async Task SendGeminiRequestAsync_ShouldHandleApiError()
        {
            // Arrange
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("API Down")
                });

            // Act
            Func<Task> act = async () => await _service.CheckJobContentAsync("Job", "Desc");

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Gemini API Error*");
        }

        private void SetupMockResponse(string responseContent)
        {
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent)
                });
        }
    }
}
