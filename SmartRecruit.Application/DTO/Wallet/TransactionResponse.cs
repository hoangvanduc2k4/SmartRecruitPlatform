namespace SmartRecruit.Application.DTO.Wallet
{
    public record TransactionResponse(
        long Id,
        long UserId,
        string UserName,
        long WalletId,
        decimal Amount,
        string Type,
        string Status,
        long? OrderCode,
        string Description,
        long? ReferenceId,
        DateTime CreatedAt
    );
}
