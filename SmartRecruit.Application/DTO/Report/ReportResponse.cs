using System;

namespace SmartRecruit.Application.DTO.Report
{
    public class ReportResponse
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public long ReporterId { get; set; }
        public string ReporterName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsProcessed { get; set; }
    }
}
