using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
