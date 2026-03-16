using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PayOS;
using PayOS.Models.Webhooks;
using SmartRecruit.Application.DTO.Payment;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Infrastructure.Configurations;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SmartRecruit.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly PayOSSettings _settings;
        private readonly PayOSClient _sdkClient;
        private readonly ILogger<PaymentService> _logger;

        private const string PayOSApiBase = "https://api-merchant.payos.vn";

        public PaymentService(
            IHttpClientFactory httpClientFactory,
            IWalletRepository walletRepository,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            IOptions<PayOSSettings> settings,
            ILogger<PaymentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _settings = settings.Value;
            _logger = logger;

            // SDK client chỉ dùng cho webhook signature verification
            _sdkClient = new PayOSClient(new PayOSOptions
            {
                ClientId = _settings.ClientId,
                ApiKey = _settings.ApiKey,
                ChecksumKey = _settings.ChecksumKey
            });
        }

        public async Task<CreatePaymentResponse> CreatePaymentLinkAsync(CreatePaymentRequest request)
        {
            _logger.LogInformation("Calling external system PayOS to CreatePaymentLinkAsync for UserId: {UserId}, Amount: {Amount}", request.UserId, request.Amount);
            var wallet = await _walletRepository.GetWalletByUserIdAsync(request.UserId)
                ?? throw new KeyNotFoundException($"Wallet not found for user {request.UserId}");

            // OrderCode: số nguyên dương <= 9007199254740991, unique mỗi lần
            var rnd = new Random();
            long orderCode = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() % 900_000_000L) + rnd.Next(1_000, 9_999);

            var returnUrl = $"{_settings.ReturnUrl}?orderCode={orderCode}";
            var cancelUrl = $"{_settings.CancelUrl}?orderCode={orderCode}";

            // Tạo signature cho request (cần cho PayOS API)
            var sigData = $"amount={request.Amount}&cancelUrl={cancelUrl}&description={request.Description}&orderCode={orderCode}&returnUrl={returnUrl}";
            using var hmacSig = new HMACSHA256(Encoding.UTF8.GetBytes(_settings.ChecksumKey));
            var sigBytes = hmacSig.ComputeHash(Encoding.UTF8.GetBytes(sigData));
            var signature = BitConverter.ToString(sigBytes).Replace("-", "").ToLowerInvariant();

            // Transaction pending trước khi redirect
            var transaction = new Transaction
            {
                UserId = request.UserId,
                WalletId = wallet.Id,
                Amount = request.Amount,
                Description = request.Description,
                OrderCode = orderCode,
                Type = TransactionType.TOPUP,
                Status = TransactionStatus.PENDING,
                IsDeleted = false
            };
            await _walletRepository.AddTransactionAsync(transaction);
            await _unitOfWork.CompleteAsync();

            // Gọi PayOS API tạo payment link
            var client = _httpClientFactory.CreateClient("PayOS");
            var body = new
            {
                orderCode,
                amount = (int)request.Amount,
                description = request.Description,
                returnUrl,
                cancelUrl,
                signature,
                expiredAt = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds()
            };

            var httpReq = new HttpRequestMessage(HttpMethod.Post, $"{PayOSApiBase}/v2/payment-requests");
            httpReq.Headers.Add("x-client-id", _settings.ClientId);
            httpReq.Headers.Add("x-api-key", _settings.ApiKey);
            httpReq.Content = JsonContent.Create(body);

            var response = await client.SendAsync(httpReq);
            var responseStr = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseStr);
            var root = doc.RootElement;

            var code = root.TryGetProperty("code", out var codeProp) ? codeProp.GetString() : null;
            if (code != "00")
            {
                var msgProp = root.TryGetProperty("desc", out var d) ? d.GetString() : responseStr;
                _logger.LogError("PayOS error [{Code}]: {Message}", code, msgProp);
                throw new InvalidOperationException($"PayOS error [{code}]: {msgProp}");
            }

            var data = root.GetProperty("data");

            return new CreatePaymentResponse(
                data.GetProperty("orderCode").GetInt64(),
                data.GetProperty("checkoutUrl").GetString() ?? string.Empty,
                data.TryGetProperty("qrCode", out var qr) ? qr.GetString() ?? string.Empty : string.Empty,
                data.TryGetProperty("status", out var st) ? st.GetString() ?? "PENDING" : "PENDING"
            );
        }

        public async Task HandleWebhookAsync(PayOSWebhookBody webhookBody)
        {
            // Kiểm tra signature, trừ khi SkipSignatureVerification = true trong config (dùng cho dev/test)
            if (!_settings.SkipSignatureVerification)
            {
                if (!string.IsNullOrEmpty(webhookBody.Signature) && webhookBody.Data != null)
                {
                    var valid = await VerifyWithSdkAsync(webhookBody);
                    if (!valid)
                        throw new UnauthorizedAccessException("Invalid PayOS webhook signature.");
                }
            }
            else
            {
                _logger.LogWarning("[DEV] Skipping PayOS webhook signature verification (SkipSignatureVerification=true)");
            }

            // Nếu hủy hoặc thất bại (code != "00") → đánh dấu FAILED = 2
            if (webhookBody.Code != "00" || webhookBody.Data == null)
            {
                if (webhookBody.Data != null)
                {
                    _logger.LogWarning("Webhook failed with code {Code}, marking transaction {OrderCode} as FAILED", webhookBody.Code, webhookBody.Data.OrderCode);
                    var failedTx = await _walletRepository.GetTransactionByOrderCodeAsync(webhookBody.Data.OrderCode);
                    if (failedTx != null && failedTx.Status == TransactionStatus.PENDING)
                    {
                        failedTx.Status = TransactionStatus.FAILED;
                        _walletRepository.UpdateTransaction(failedTx);
                        await _unitOfWork.CompleteAsync();
                    }
                }
                return;
            }

            var orderCode = webhookBody.Data.OrderCode;
            var transaction = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);

            // Idempotent: bỏ qua nếu đã xử lý
            if (transaction == null || transaction.Status == TransactionStatus.SUCCESS)
                return;

            // Đánh dấu thành công
            transaction.Status = TransactionStatus.SUCCESS;
            _walletRepository.UpdateTransaction(transaction);

            // Cộng tiền vào Wallet
            var wallet = await _walletRepository.GetByIdAsync(transaction.WalletId);
            if (wallet != null)
            {
                wallet.Balance += transaction.Amount;
                _walletRepository.Update(wallet);
                _logger.LogInformation("External system PayOS Transaction {OrderCode} SUCCESS. Added {Amount} to Wallet {WalletId}", orderCode, transaction.Amount, wallet.Id);

                // Real-time Notification for Payment Success
                try
                {
                    await _notificationService.SendNotificationAsync(
                        transaction.UserId,
                        "Deposit Successful",
                        $"Successfully deposited {transaction.Amount:N0} VNĐ via PayOS. Your new balance is: {wallet.Balance:N0} VNĐ.",
                        NotificationType.PAYMENT,
                        "/Wallet");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send deposit success notification for User {UserId}", transaction.UserId);
                }
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelTransactionAsync(long orderCode)
        {
            var transaction = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);
            if (transaction == null || transaction.Status != TransactionStatus.PENDING)
                return;

            transaction.Status = TransactionStatus.FAILED;
            _walletRepository.UpdateTransaction(transaction);
            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("External system PayOS Transaction {OrderCode} cancelled and marked as FAILED", orderCode);
        }

        /// <summary>
        /// Gọi PayOS API để check trạng thái order, nếu PAID → credit wallet.
        /// Dùng làm fallback tại /payment/success khi webhook không forward được (môi trường dev).
        /// </summary>
        public async Task<bool> ConfirmPaymentByOrderCodeAsync(long orderCode)
        {
            try
            {
                var transaction = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);
                if (transaction == null)
                {
                    _logger.LogWarning("ConfirmPaymentByOrderCode: Transaction not found for orderCode {OrderCode}", orderCode);
                    return false;
                }

                // Idempotent: đã SUCCESS rồi thì không xử lý lại
                if (transaction.Status == TransactionStatus.SUCCESS)
                {
                    _logger.LogInformation("ConfirmPaymentByOrderCode: orderCode {OrderCode} already SUCCESS", orderCode);
                    return true;
                }

                // Gọi PayOS API query payment link status
                var client = _httpClientFactory.CreateClient("PayOS");
                var httpReq = new HttpRequestMessage(HttpMethod.Get, $"{PayOSApiBase}/v2/payment-requests/{orderCode}");
                httpReq.Headers.Add("x-client-id", _settings.ClientId);
                httpReq.Headers.Add("x-api-key", _settings.ApiKey);

                var response = await client.SendAsync(httpReq);
                var responseStr = await response.Content.ReadAsStringAsync();

                _logger.LogInformation("ConfirmPaymentByOrderCode: PayOS responded {Status}: {Body}", response.StatusCode, responseStr);

                using var doc = JsonDocument.Parse(responseStr);
                var root = doc.RootElement;

                if (!root.TryGetProperty("code", out var codeEl) || codeEl.GetString() != "00")
                {
                    _logger.LogWarning("ConfirmPaymentByOrderCode: PayOS query failed for {OrderCode}: {Body}", orderCode, responseStr);
                    return false;
                }

                // Lấy status từ data.status
                var dataEl = root.GetProperty("data");
                var status = dataEl.TryGetProperty("status", out var stEl) ? stEl.GetString() : null;

                if (status != "PAID")
                {
                    _logger.LogInformation("ConfirmPaymentByOrderCode: orderCode {OrderCode} status={Status}, not PAID yet", orderCode, status);
                    return false;
                }

                // PAID → credit wallet
                transaction.Status = TransactionStatus.SUCCESS;
                _walletRepository.UpdateTransaction(transaction);

                var wallet = await _walletRepository.GetByIdAsync(transaction.WalletId);
                if (wallet != null)
                {
                    wallet.Balance += transaction.Amount;
                    _walletRepository.Update(wallet);
                    _logger.LogInformation("ConfirmPaymentByOrderCode: orderCode {OrderCode} PAID. Added {Amount} to Wallet {WalletId}", orderCode, transaction.Amount, wallet.Id);

                    // Real-time Notification for Payment Success
                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            transaction.UserId,
                            "Deposit Successful",
                            $"Successfully deposited {transaction.Amount:N0} VNĐ via PayOS. Your new balance is: {wallet.Balance:N0} VNĐ.",
                            NotificationType.PAYMENT,
                            "/Wallet");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to send deposit success notification for User {UserId}", transaction.UserId);
                    }
                }

                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ConfirmPaymentByOrderCode: Error for orderCode {OrderCode}", orderCode);
                return false;
            }
        }

        /// <summary>
        /// Dùng PayOS SDK's built-in VerifyAsync — đây là cách chính xác nhất.
        /// SDK biết đúng field set và format của signature.
        /// </summary>
        private async Task<bool> VerifyWithSdkAsync(PayOSWebhookBody body)
        {
            try
            {
                if (body.Data == null) return false;

                var webhookData = new WebhookData
                {
                    OrderCode  = body.Data.OrderCode,
                    Amount     = body.Data.Amount,
                    Description = body.Data.Description,
                    AccountNumber       = body.Data.AccountNumber     ?? string.Empty,
                    Reference           = body.Data.Reference         ?? string.Empty,
                    TransactionDateTime = body.Data.TransactionDateTime ?? string.Empty,
                    Currency            = body.Data.Currency           ?? string.Empty,
                    PaymentLinkId       = body.Data.PaymentLinkId      ?? string.Empty,
                    Code                = body.Data.Code               ?? string.Empty,
                    CounterAccountBankId   = body.Data.CounterAccountBankId   ?? string.Empty,
                    CounterAccountBankName = body.Data.CounterAccountBankName ?? string.Empty,
                    CounterAccountName     = body.Data.CounterAccountName,   // nullable — null OK
                    CounterAccountNumber   = body.Data.CounterAccountNumber  ?? string.Empty,
                    VirtualAccountName     = body.Data.VirtualAccountName    ?? string.Empty,
                    VirtualAccountNumber   = body.Data.VirtualAccountNumber  ?? string.Empty,
                };

                // Description2 property maps to JSON "desc" — set via reflection
                // vì tên C# khác với tên JSON property
                typeof(WebhookData).GetProperty("Description2")
                    ?.SetValue(webhookData, body.Data.Desc ?? string.Empty);

                var webhook = new Webhook
                {
                    Code      = body.Code,
                    Success   = body.Success,
                    Signature = body.Signature,
                    Data      = webhookData,
                };

                // Webhook.Description maps to JSON "desc" (top-level)
                typeof(Webhook).GetProperty("Description")
                    ?.SetValue(webhook, body.Desc ?? string.Empty);

                var result = await _sdkClient.Webhooks.VerifyAsync(webhook);
                return result != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[PAYOS VERIFY ERROR] {Message}", ex.Message);
                return false;
            }
        }
    }
}
