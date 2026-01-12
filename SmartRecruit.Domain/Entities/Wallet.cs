using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public long UserId { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Currency { get; set; } = "VND";

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}