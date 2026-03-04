using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Payment;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        /// <summary>
        /// Tạo link thanh toán PayOS để nạp tiền vào ví
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreatePaymentLink([FromBody] CreatePaymentRequest request)
        {
            var result = await _paymentService.CreatePaymentLinkAsync(request);
            return Ok(result.Wrap("Payment link created successfully."));
        }

        /// <summary>
        /// Webhook callback từ PayOS khi thanh toán hoàn tất.
        /// Đọc raw body để đảm bảo parse đúng, log để debug signature.
        /// </summary>
        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            try
            {
                // Đọc raw body
                Request.EnableBuffering();
                using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
                var rawBody = await reader.ReadToEndAsync();
                Request.Body.Position = 0;

                _logger.LogInformation("API Webhook called, BodyLength={Len}", rawBody.Length);

                // Parse thành DTO
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var webhookBody = JsonSerializer.Deserialize<PayOSWebhookBody>(rawBody, options);

                if (webhookBody == null)
                    return Ok(new { success = false, message = "Cannot deserialize webhook body." });

                await _paymentService.HandleWebhookAsync(webhookBody);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PayOS Webhook handling failed.");
                return Ok(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// PayOS redirect về khi thanh toán thành công.
        /// Gọi PayOS API để verify và credit wallet ngay tại đây (không cần webhook).
        /// </summary>
        [HttpGet("success")]
        public async Task<IActionResult> PaymentSuccess([FromQuery] long orderCode)
        {
            _logger.LogInformation("API PaymentSuccess called with orderCode={OrderCode}", orderCode);
            var confirmed = await _paymentService.ConfirmPaymentByOrderCodeAsync(orderCode);
            if (confirmed)
                return Ok(new { message = "Payment confirmed. Wallet has been updated.", orderCode });
            else
                return Ok(new { message = "Payment completed but wallet update pending (may have already been processed).", orderCode });
        }

        /// <summary>
        /// PayOS redirect về khi hủy thanh toán
        /// </summary>
        [HttpGet("cancel")]
        public async Task<IActionResult> PaymentCancel([FromQuery] long orderCode)
        {
            _logger.LogInformation("API PaymentCancel called with orderCode={OrderCode}", orderCode);
            await _paymentService.CancelTransactionAsync(orderCode);
            return Ok(new { message = "Payment cancelled.", orderCode });
        }
    }
}
