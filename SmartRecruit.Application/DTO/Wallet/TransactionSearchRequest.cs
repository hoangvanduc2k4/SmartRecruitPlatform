namespace SmartRecruit.Application.DTO.Wallet
{
    public record TransactionSearchRequest(
        long? UserId,
        long? WalletId,
        int? Type,
        int? Status,
        int Page = 1,
        int PageSize = 10
    );
}
