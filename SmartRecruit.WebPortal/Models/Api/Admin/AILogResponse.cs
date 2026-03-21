using System;

namespace WebPortal.Models.Api.Admin
{
    public class AILogResponse
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public string? AIType { get; set; }
        public string? InputText { get; set; }
        public string? OutputResult { get; set; }
        public string? Decision { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
