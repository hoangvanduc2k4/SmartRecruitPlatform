namespace SmartRecruit.Application.DTO.Payment
{
    public record CreatePaymentRequest(
        long UserId,
        int Amount,       // PayOS yêu cầu số nguyên (VND)
        string Description
    );
}
