namespace SmartRecruit.Infrastructure.Configurations
{
    public class GeminiSettings
    {
        public string Url { get; set; } = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";
        public string ApiKey { get; set; } = string.Empty;
    }
}
