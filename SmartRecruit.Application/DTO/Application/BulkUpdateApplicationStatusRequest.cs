using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Application
{
    public class BulkUpdateApplicationStatusRequest
    {
        public List<long> ApplicationIds { get; set; } = new();
        public ApplicationStatus Status { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? RejectionReason { get; set; }
    }
}
