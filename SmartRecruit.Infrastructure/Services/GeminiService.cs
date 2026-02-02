using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace SmartRecruit.Infrastructure.Services
{
    public class GeminiService : IGeminiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public GeminiService(HttpClient httpClient, IOptions<GeminiSettings> config)
        {
            _httpClient = httpClient;
            var apiKey = config.Value.ApiKey;
            var baseUrl = config.Value.Url;

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(baseUrl))
            {
                throw new Exception("Missing configuration for Gemini API.");
            }

            _apiUrl = $"{baseUrl}?key={apiKey}";
        }

        public async Task<JobScreeningResponse> CheckJobContentAsync(string title, string description)
        {
            string prompt = $@"
                Bạn là AI Moderator. Phân tích tin tuyển dụng:
                Tiêu đề: {title}
                Mô tả: {description}
                YÊU CẦU: Trả về JSON (không markdown) theo mẫu:
                {{
                    ""IsSafe"": (bool),
                    ""RiskLevel"": ""(Low/Medium/High)"",
                    ""ViolationType"": ""(None/Scam/Discrimination/Spam)"",
                    ""Analysis"": ""(string)""
                }}";

            return await SendGeminiRequestAsync<JobScreeningResponse>(prompt);
        }

        private async Task<T> SendGeminiRequestAsync<T>(string prompt)
        {
            var requestBody = new
            {
                contents = new[] { new { parts = new[] { new { text = prompt } } } }
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini API Error ({response.StatusCode}): {responseString}");
            }

            dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
            if (jsonResponse?.candidates == null || jsonResponse.candidates.Count == 0)
            {
                throw new Exception($"No content returned. Raw: {responseString}");
            }

            string aiText = jsonResponse.candidates[0].content.parts[0].text;
            aiText = aiText.Replace("```json", "").Replace("```", "").Trim();

            try
            {
                return JsonConvert.DeserializeObject<T>(aiText);
            }
            catch
            {
                throw new Exception($"Invalid JSON format: {aiText}");
            }
        }
    }
}
