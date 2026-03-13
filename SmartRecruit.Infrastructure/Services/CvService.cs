using Microsoft.Extensions.Logging;
using SmartRecruit.Application.Interfaces.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace SmartRecruit.Infrastructure.Services
{
    public class CvService : ICvService
    {
        private readonly ILogger<CvService> _logger;

        public CvService(ILogger<CvService> logger)
        {
            _logger = logger;
        }

        public Task<string> ExtractTextAsync(Stream pdfStream)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                if (pdfStream.CanSeek)
                {
                    pdfStream.Position = 0;
                }
                pdfStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                using var document = PdfDocument.Open(memoryStream);
                var textBuilder = new StringBuilder();

                foreach (var page in document.GetPages())
                {
                    var words = page.GetWords();

                    if (words != null && words.Any())
                    {
                        var pageText = string.Join(" ", words.Select(w => w.Text));
                        textBuilder.AppendLine(pageText);
                    }
                }
                var rawText = textBuilder.ToString();

                var cleanText = Regex.Replace(rawText, @"[\x00-\x08\x0B\x0C\x0E-\x1F]", "");

                cleanText = cleanText.Replace("\uFFFD", " ");

                return Task.FromResult(cleanText);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extracting text from PDF.");
                return Task.FromResult(string.Empty);
            }
        }
    }
}
