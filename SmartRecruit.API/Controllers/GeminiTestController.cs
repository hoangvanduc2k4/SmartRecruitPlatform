using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.DTO.Job;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRecruit.Application.Interfaces.Repositories;
using UglyToad.PdfPig;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeminiTestController : ControllerBase
    {
        private readonly IGeminiService _geminiService;
        private readonly IJobRepository _jobRepository;

        public GeminiTestController(IGeminiService geminiService, IJobRepository jobRepository)
        {
            _geminiService = geminiService;
            _jobRepository = jobRepository;
        }

        [HttpPost("score-cv")]
        public async Task<IActionResult> ScoreCv([FromBody] ScoreCvRequest request)
        {
            if (string.IsNullOrEmpty(request.CvContent) || string.IsNullOrEmpty(request.JobDescription))
            {
                return BadRequest("CV Content and Job Description are required.");
            }

            var result = await _geminiService.ScoreCvAsync(request.CvContent, request.JobDescription);
            return Ok(result);
        }

        [HttpPost("score-cv-file")]
        public async Task<IActionResult> ScoreCvWithFile([FromForm] long jobId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".pdf")
                return BadRequest("Only PDF files are supported for this test.");

            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null)
                return NotFound($"Job with ID {jobId} not found.");

            string cvText = "";
            using (var stream = file.OpenReadStream())
            {
                try
                {
                    using (var pdf = PdfDocument.Open(stream))
                    {
                        foreach (var page in pdf.GetPages())
                        {
                            cvText += page.Text + " ";
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return BadRequest($"Error reading PDF: {ex.Message}");
                }
            }

            if (string.IsNullOrWhiteSpace(cvText))
                return BadRequest("Could not extract text from PDF.");

            var result = await _geminiService.ScoreCvAsync(cvText, job.Description);
            return Ok(result);
        }

        public class ScoreCvRequest
        {
            public string CvContent { get; set; }
            public string JobDescription { get; set; }
        }
    }
}
