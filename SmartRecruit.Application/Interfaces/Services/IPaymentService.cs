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
        Task HandleWebhookAsync(PayOSWebhookBody webhookBody);

        /// <summary>
        /// Đánh dấu transaction là FAILED khi user hủy thanh toán (browser redirect về /cancel)
        /// </summary>
        Task CancelTransactionAsync(long orderCode);

        /// <summary>
        /// Gọi PayOS API để verify trạng thái thanh toán theo orderCode.
        /// Nếu PAID → credit wallet. Dùng khi webhook không deliver được (dev/local).
        /// </summary>
        Task<bool> ConfirmPaymentByOrderCodeAsync(long orderCode);

        /// <summary>
        /// Lấy link thanh toán của một transaction đã tồn tại (nếu còn hiệu lực)
        /// </summary>
        Task<string?> GetPaymentLinkByOrderCodeAsync(long orderCode);
    }
}
