using SmartRecruit.Domain.Commons;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public long UserId { get; set; }
        public long WalletId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.PENDING;
        public long? OrderCode { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual User User { get; set; } = null!;
        public virtual Wallet Wallet { get; set; } = null!;
    }
}