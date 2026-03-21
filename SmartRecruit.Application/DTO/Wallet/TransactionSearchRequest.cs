namespace SmartRecruit.Application.DTO.Wallet
{
    public class TransactionSearchRequest
    {
        public long? UserId { get; set; }
        public long? WalletId { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
