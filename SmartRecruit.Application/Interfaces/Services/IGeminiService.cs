using System.Threading.Tasks;
using SmartRecruit.Application.DTO.Job;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IGeminiService
    {
        Task<JobScreeningResponse> CheckJobContentAsync(string title, string description);
        Task<CvScreeningResponse> ScoreCvAsync(string cvContent, string jobDescription);
    }
}
