using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;
using WebPortal.Pages;

namespace WebPortal.Pages;

public class IndexModel : BasePageModel
{
    private readonly IJobApiService _jobApiService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IJobApiService jobApiService)
    {
        _logger = logger;
        _jobApiService = jobApiService;
    }

    public IEnumerable<Job> RecommendedJobs { get; set; } = new List<Job>();
    public HashSet<long> SavedJobIds { get; set; } = new HashSet<long>();

    public async Task<IActionResult> OnGetAsync()
    {
        // Fetch recommendations if candidate
        if (IsAuthenticated && IsCandidate)
        {
            try
            {
                var recommendations = await _jobApiService.GetRecommendedJobsAsync();
                RecommendedJobs = recommendations.Take(5);

                var savedJobs = await _jobApiService.GetSavedJobsAsync(CurrentUserId!.Value, 1, 100);
                if (savedJobs.Success && savedJobs.Data != null)
                {
                    SavedJobIds = new HashSet<long>(savedJobs.Data.Select(j => j.Id));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching recommended jobs for home page");
            }
        }

        return Page();
    }

    public async Task<IActionResult> OnPostToggleSaveAsync(long jobId)
    {
        var currentUserId = CurrentUserId;
        if (!currentUserId.HasValue) return RedirectToPage("/Account/Auth");

        await _jobApiService.ToggleSaveJobAsync(jobId, currentUserId.Value);
        return RedirectToPage();
    }
}
