namespace SmartRecruit.Application.DTO.Payment
{
    public record CreatePaymentResponse(
        long OrderCode,
        string PaymentUrl,
        string QrCode,
        string Status
    );
}
