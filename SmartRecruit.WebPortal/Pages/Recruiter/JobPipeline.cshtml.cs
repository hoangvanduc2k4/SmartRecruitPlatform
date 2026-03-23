using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Recruiter
{
    public class JobPipelineModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public JobPipelineModel(IJobApiService jobApiService, IApplicationApiService applicationApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
        }

        public Job? Job { get; set; }
        public IList<Application> Applications { get; set; } = new List<Application>();

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            Job = await _jobApiService.GetJobByIdAsync(id.ToString());
            if (Job != null)
            {
                var response = await _applicationApiService.GetApplicationsByJobAsync(id, 1, 100);
                if (response.Data != null)
                {
                    Applications = response.Data.ToList();
                }
            }
            else
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long applicationId, string status, long jobId, DateTime? interviewDate, string? rejectionReason)
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            Console.WriteLine($"[JobPipeline] Updating Status - AppId: {applicationId}, Status: {status}, JobId: {jobId}, Date: {interviewDate}, Reason: {rejectionReason}");

            if (!ModelState.IsValid)
            {
                var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ErrorMessage = $"Lỗi liên kết: {errors}";
                return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
            }

            if (System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
            {
                if (nextStatus == ApplicationStatus.INTERVIEWING && interviewDate.HasValue && interviewDate.Value < DateTime.Now)
                {
                    ErrorMessage = "Ngày phỏng vấn không được trong quá khứ.";
                    return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
                }

                var request = new UpdateApplicationStatusRequest 
                { 
                    Status = nextStatus,
                    InterviewDate = interviewDate,
                    RejectionReason = rejectionReason
                };
                
                var result = await _applicationApiService.UpdateStatusAsync(applicationId, request);
                if (result.Success)
                {
                    SuccessMessage = "Cập nhật trạng thái thành công.";
                }
                else
                {
                    ErrorMessage = $"Thất bại: {result.Message}";
                }
            }
            
            return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
        }

        public async Task<IActionResult> OnPostRestoreAsync(long applicationId, long jobId)
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            var success = await _applicationApiService.RestoreStatusAsync(applicationId);
            if (success)
            {
                SuccessMessage = "Hồ sơ đã được khôi phục thành công.";
            }
            else
            {
                ErrorMessage = "Không thể khôi phục hồ sơ.";
            }
            return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
        }
    }
}
