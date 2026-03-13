namespace SmartRecruit.Application.DTO.Job
{
    public record RecruiterStatsResponse(
        int TotalViews,
        int TotalSaves,
        int TotalApplications,
        double ApplyToSaveRatio
    );
}
