using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class SavedJob : BaseEntity
    {
        public long UserId { get; set; }
        public long JobId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
