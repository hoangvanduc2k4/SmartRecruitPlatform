namespace WebPortal.Models
{
    public enum UserRole
    {
        CANDIDATE,
        RECRUITER,
        ADMIN
    }

    public enum JobStatus
    {
        CHECKING = 0,
        APPROVED = 1,
        BLOCKED = 2,
        HIDDEN = 3,
        DRAFT = 4,
        EXPIRED = 5,
        EXPIRING_SOON = 6
    }

    public enum JobType
    {
        FULL_TIME = 0,
        PART_TIME = 1,
        REMOTE = 2
    }

    public enum ApplicationStatus
    {
        REVIEWING = 0,
        INTERVIEWING = 1,
        OFFERED = 2,
        REJECTED = 3
    }
}
