namespace SmartRecruit.Application.DTO.Wallet
{
    public record WalletResponse(
        long Id,
        long UserId,
        string UserFullName,
        string UserEmail,
        decimal Balance,
        string Currency,
        DateTime CreatedAt
    );
}
