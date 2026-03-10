using Microsoft.Extensions.Logging;
using SmartRecruit.Application.Interfaces.Services;
using UglyToad.PdfPig;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartRecruit.Application.Services
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
                // Ensure the stream is at the beginning
                if (pdfStream.CanSeek)
                {
                    pdfStream.Position = 0;
                }

                using var document = PdfDocument.Open(pdfStream);
                var textBuilder = new StringBuilder();

                foreach (var page in document.GetPages())
                {
                    textBuilder.AppendLine(page.Text);
                }

                return Task.FromResult(textBuilder.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extracting text from PDF.");
                return Task.FromResult(string.Empty);
            }
        }
    }
}
