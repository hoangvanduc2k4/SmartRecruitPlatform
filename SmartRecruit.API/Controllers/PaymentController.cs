
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Payment;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using System.Text;
using System.Text.Json;
using SmartRecruit.API.Controllers;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Exceptions;
namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : BaseController
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
            var finalRequest = request with
            {
                UserId = CurrentUserId,
                Description = string.IsNullOrEmpty(request.Description) ? $"Deposit {request.Amount:N0} VNĐ" : request.Description
            };

            var result = await _paymentService.CreatePaymentLinkAsync(finalRequest);
            return Ok(result.Wrap("Tạo liên kết thanh toán thành công."));
        }

        /// <summary>
        /// Webhook callback từ PayOS khi thanh toán hoàn tất.
        /// Đọc raw body để đảm bảo parse đúng, log để debug signature.
        /// </summary>
        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            // Đọc raw body
            Request.EnableBuffering();
            using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
            var rawBody = await reader.ReadToEndAsync();
            Request.Body.Position = 0;

            // Parse thành DTO
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var webhookBody = JsonSerializer.Deserialize<PayOSWebhookBody>(rawBody, options);

            if (webhookBody == null) throw new BadRequestException("Cannot deserialize webhook body.");

            await _paymentService.HandleWebhookAsync(webhookBody);
            return Ok(new { success = true });
        }

        /// <summary>
        /// PayOS redirect về khi thanh toán thành công.
        /// Gọi PayOS API để verify và credit wallet ngay tại đây (không cần webhook).
        /// </summary>
        [HttpGet("success")]
        public async Task<IActionResult> PaymentSuccess([FromQuery] long orderCode)
        {
            _logger.LogInformation("API PaymentSuccess called with orderCode={OrderCode}", orderCode);
            await _paymentService.ConfirmPaymentByOrderCodeAsync(orderCode);
            return Redirect($"https://localhost:7070/Wallet?success=true&orderCode={orderCode}");
        }

        /// <summary>
        /// PayOS redirect về khi hủy thanh toán
        /// </summary>
        [HttpGet("cancel")]
        public async Task<IActionResult> PaymentCancel([FromQuery] long orderCode)
        {
            _logger.LogInformation("API PaymentCancel called with orderCode={OrderCode}", orderCode);
            await _paymentService.CancelTransactionAsync(orderCode);
            return Redirect($"https://localhost:7070/Wallet?cancel=true&orderCode={orderCode}");
        }

        /// <summary>
        /// Lấy link thanh toán cho một orderCode hiện có (để thanh toán lại)
        /// </summary>
        [HttpGet("{orderCode}/link")]
        public async Task<IActionResult> GetPaymentLink(long orderCode)
        {
            var link = await _paymentService.GetPaymentLinkByOrderCodeAsync(orderCode);
            return Ok(new { paymentUrl = link }.Wrap());
        }
    }
}
