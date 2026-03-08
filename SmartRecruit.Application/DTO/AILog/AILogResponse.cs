using SmartRecruit.Domain.Enums;
using System;

namespace SmartRecruit.Application.DTO.AILog
{
    public class AILogResponse
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long JobId { get; set; }
        public AIType AIType { get; set; }
        public string InputText { get; set; } = string.Empty;
        public string OutputResult { get; set; } = string.Empty;
        public string Decision { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
