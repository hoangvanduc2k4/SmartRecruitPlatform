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
                // Đọc raw body để debug
                Request.EnableBuffering();
                using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
                var rawBody = await reader.ReadToEndAsync();
                Request.Body.Position = 0;

                _logger.LogDebug("API Webhook called with rawBody: {RawBody}", rawBody);

                // Parse thành DTO
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var webhookBody = JsonSerializer.Deserialize<PayOSWebhookBody>(rawBody, options);

                if (webhookBody == null)
                    return Ok(new { success = false, message = "Cannot deserialize webhook body." });

                await _paymentService.HandleWebhookAsync(webhookBody, rawBody);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PayOS Webhook handling failed.");
                return Ok(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// PayOS redirect về khi thanh toán thành công (chỉ dùng cho frontend redirect)
        /// </summary>
        [HttpGet("success")]
        public IActionResult PaymentSuccess([FromQuery] long orderCode)
        {
            _logger.LogInformation("API PaymentSuccess called with orderCode={OrderCode}", orderCode);
            return Ok(new { message = "Payment completed. Your wallet will be updated shortly.", orderCode });
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
