using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class Report : BaseEntity
    {
        public long JobId { get; set; }
        public long ReporterId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public bool IsProcessed { get; set; } = false;

        public virtual Job Job { get; set; } = null!;
        public virtual User Reporter { get; set; } = null!;
    }
}