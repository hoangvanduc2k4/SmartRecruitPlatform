using System.IO;
using System.Threading.Tasks;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ICloudinaryService
    {
        Task<string> ManageFileAsync(Stream? fileStream, string? fileName, string? publicIdOrUrl);
    }
}
