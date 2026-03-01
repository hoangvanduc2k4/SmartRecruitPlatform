namespace SmartRecruitWeb.Models
{
    public enum UserRole
    {
        CANDIDATE,
        RECRUITER,
        ADMIN
    }

    public enum JobStatus
    {
        PENDING,
        PUBLISHED,
        CLOSED,
        EXPIRED,
        BLOCKED
    }

    public enum JobType
    {
        FULL_TIME,
        PART_TIME,
        REMOTE
    }

    public enum ApplicationStatus
    {
        APPLIED,
        SCREENING,
        INTERVIEW,
        OFFERED,
        REJECTED
    }
}
