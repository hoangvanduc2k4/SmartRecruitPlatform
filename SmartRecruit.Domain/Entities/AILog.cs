using SmartRecruit.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartRecruit.Domain.Entities
{
    public class AILog
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public long JobId { get; set; }
        public AIType AIType { get; set; }
        public string InputText { get; set; } = string.Empty;
        public string OutputResult { get; set; } = string.Empty;
        public string Decision { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
