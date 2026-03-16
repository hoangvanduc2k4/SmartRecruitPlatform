namespace WebPortal.Models.Api.Admin
{
    public class TransactionResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty; // Added in WebPortal for display convenience if mapping exists
        public long WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // TOPUP, SPEND, etc.
        public string Status { get; set; } = string.Empty; // PENDING, SUCCESS, FAILED
        public long? OrderCode { get; set; }
        public string Description { get; set; } = string.Empty;
        public long? ReferenceId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
