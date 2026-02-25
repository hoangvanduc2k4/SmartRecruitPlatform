using SmartRecruit.Application.DTO.Payment;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        /// <summary>
        /// Tạo link thanh toán PayOS để nạp tiền vào ví
        /// </summary>
        Task<CreatePaymentResponse> CreatePaymentLinkAsync(CreatePaymentRequest request);

        /// <summary>
        /// Xử lý Webhook từ PayOS khi thanh toán hoàn tất.
        /// Nhận raw JSON body từ PayOS để tự verify và xử lý.
        /// </summary>
        Task HandleWebhookAsync(PayOSWebhookBody webhookBody, string rawBody);

        /// <summary>
        /// Đánh dấu transaction là FAILED khi user hủy thanh toán (browser redirect về /cancel)
        /// </summary>
        Task CancelTransactionAsync(long orderCode);
    }
}
