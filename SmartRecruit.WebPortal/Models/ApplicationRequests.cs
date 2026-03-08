namespace WebPortal.Models
{
    public class UpdateApplicationStatusRequest
    {
        public ApplicationStatus Status { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? RejectionReason { get; set; }
    }

    public class BulkUpdateApplicationStatusRequest
    {
        public List<long> ApplicationIds { get; set; } = new List<long>();
        public ApplicationStatus Status { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? RejectionReason { get; set; }
    }
}
