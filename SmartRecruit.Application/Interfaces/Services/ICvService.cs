using System.IO;
using System.Threading.Tasks;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ICvService
    {
        /// <summary>
        /// Extracts text from a PDF stream.
        /// </summary>
        /// <param name="pdfStream">The PDF file stream.</param>
        /// <returns>The extracted text content.</returns>
        Task<string> ExtractTextAsync(Stream pdfStream);
    }
}
