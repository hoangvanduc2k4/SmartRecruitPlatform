using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.Interfaces.Services;
using System.IO;
using System.Threading.Tasks;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryTestController : ControllerBase
    {
        private readonly ICloudinaryService _cloudinaryService;

        public CloudinaryTestController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();
            var result = await _cloudinaryService.ManageFileAsync(stream, file.FileName, null);

            return Ok(new { Url = result });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string publicIdOrUrl)
        {
            if (string.IsNullOrEmpty(publicIdOrUrl))
                return BadRequest("PublicIdOrUrl is required.");

            var result = await _cloudinaryService.ManageFileAsync(null, null, publicIdOrUrl);

            return Ok(new { Result = result });
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(IFormFile file, string? oldUrl)
        {
             if (file == null || file.Length == 0)
                return BadRequest("No new file uploaded.");

            using var stream = file.OpenReadStream();
            var result = await _cloudinaryService.ManageFileAsync(stream, file.FileName, oldUrl);

            return Ok(new { Url = result });
        }
    }
}
