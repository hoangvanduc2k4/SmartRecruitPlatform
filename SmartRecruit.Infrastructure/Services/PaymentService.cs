
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
        private readonly PayOSClient _sdkClient; // Keep for webhook verification
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

            // SDK client dùng cho webhook signature verification
            _sdkClient = new PayOSClient(new PayOSOptions
            {
                ClientId = _settings.ClientId,
                ApiKey = _settings.ApiKey,
                ChecksumKey = _settings.ChecksumKey
            });
        }

        public async Task<CreatePaymentResponse> CreatePaymentLinkAsync(CreatePaymentRequest request)
        {
            _logger.LogInformation("Creating Payment Link for UserId: {UserId}, Amount: {Amount}", request.UserId, request.Amount);

            var wallet = await _walletRepository.GetWalletByUserIdAsync(request.UserId)
                ?? throw new KeyNotFoundException($"Không tìm thấy ví cho người dùng {request.UserId}");

            long orderCode = GenerateOrderCode();

            // Fix signature calculation: amount MUST be integer string
            int amountInt = (int)request.Amount;

            // Transaction pending
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

            var checkoutUrl = await CreatePayOSRequestAsync(orderCode, amountInt, request.Description);
            if (string.IsNullOrEmpty(checkoutUrl))
            {
                throw new Exception("Không thể tạo liên kết thanh toán với cổng PayOS.");
            }

            return new CreatePaymentResponse(orderCode, checkoutUrl, string.Empty, "PENDING");
        }

        private async Task<string?> CreatePayOSRequestAsync(long orderCode, int amountInt, string description)
        {
            try
            {
                var returnUrl = $"{_settings.ReturnUrl}?orderCode={orderCode}";
                var cancelUrl = $"{_settings.CancelUrl}?orderCode={orderCode}";
                var sigData = $"amount={amountInt}&cancelUrl={cancelUrl}&description={description}&orderCode={orderCode}&returnUrl={returnUrl}";

                using var hmacSig = new HMACSHA256(Encoding.UTF8.GetBytes(_settings.ChecksumKey));
                var sigBytes = hmacSig.ComputeHash(Encoding.UTF8.GetBytes(sigData));
                var signature = BitConverter.ToString(sigBytes).Replace("-", "").ToLowerInvariant();

                var client = _httpClientFactory.CreateClient("PayOS");
                var body = new
                {
                    orderCode,
                    amount = amountInt,
                    description,
                    returnUrl,
                    cancelUrl,
                    signature
                };

                var response = await client.PostAsJsonAsync($"{PayOSApiBase}/v2/payment-requests", body);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("PayOS POST failed for {OrderCode}: {Status} - {Body}", orderCode, response.StatusCode, responseStr);
                    return null;
                }

                using var doc = JsonDocument.Parse(responseStr);
                var root = doc.RootElement;
                if (root.GetProperty("code").GetString() == "00")
                {
                    return root.GetProperty("data").GetProperty("checkoutUrl").GetString();
                }

                _logger.LogWarning("PayOS POST returned non-zero code for {OrderCode}: {Code}", orderCode, root.GetProperty("code").GetString());
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in CreatePayOSRequestAsync for {OrderCode}", orderCode);
                return null;
            }
        }

        public async Task HandleWebhookAsync(PayOSWebhookBody webhookBody)
        {
            if (!_settings.SkipSignatureVerification)
            {
                if (!string.IsNullOrEmpty(webhookBody.Signature) && webhookBody.Data != null)
                {
                    var valid = await VerifyWithSdkAsync(webhookBody);
                    if (!valid)
                        throw new UnauthorizedAccessException("Chữ ký webhook PayOS không hợp lệ.");
                }
            }
            else
            {
                _logger.LogWarning("[DEV] Skipping PayOS webhook signature verification (SkipSignatureVerification=true)");
            }

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

            if (transaction == null || transaction.Status == TransactionStatus.SUCCESS)
                return;

            transaction.Status = TransactionStatus.SUCCESS;
            _walletRepository.UpdateTransaction(transaction);

            var wallet = await _walletRepository.GetByIdAsync(transaction.WalletId);
            if (wallet != null)
            {
                wallet.Balance += transaction.Amount;
                _walletRepository.Update(wallet);
                _logger.LogInformation("Webhook: Transaction {OrderCode} SUCCESS. Added {Amount} to Wallet {WalletId}", orderCode, transaction.Amount, wallet.Id);

                try
                {
                    await _notificationService.SendNotificationAsync(
                        transaction.UserId,
                        "Nạp tiền thành công",
                        $"Nạp thành công {transaction.Amount:N0} VNĐ qua PayOS. Số dư mới của bạn là: {wallet.Balance:N0} VNĐ.",
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
            _logger.LogInformation("Transaction {OrderCode} cancelled and marked as FAILED", orderCode);
        }

        public async Task<bool> ConfirmPaymentByOrderCodeAsync(long orderCode)
        {
            try
            {
                var transaction = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);
                if (transaction == null) return false;

                if (transaction.Status == TransactionStatus.SUCCESS) return true;

                // Manual API query for stability
                var client = _httpClientFactory.CreateClient("PayOS");
                var httpReq = new HttpRequestMessage(HttpMethod.Get, $"{PayOSApiBase}/v2/payment-requests/{orderCode}");
                // Headers are in client

                var response = await client.SendAsync(httpReq);
                var responseStr = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(responseStr);
                var root = doc.RootElement;

                if (!root.TryGetProperty("code", out var codeEl) || codeEl.GetString() != "00")
                {
                    _logger.LogWarning("ConfirmPayment: PayOS query failed for {OrderCode}: {Body}", orderCode, responseStr);
                    return false;
                }

                var dataEl = root.GetProperty("data");
                var status = dataEl.TryGetProperty("status", out var stEl) ? stEl.GetString() : null;

                if (status != "PAID") return false;

                transaction.Status = TransactionStatus.SUCCESS;
                _walletRepository.UpdateTransaction(transaction);

                var wallet = await _walletRepository.GetByIdAsync(transaction.WalletId);
                if (wallet != null)
                {
                    wallet.Balance += transaction.Amount;
                    _walletRepository.Update(wallet);
                    _logger.LogInformation("ConfirmPayment: orderCode {OrderCode} PAID. Added {Amount} to Wallet {WalletId}", orderCode, transaction.Amount, wallet.Id);

                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            transaction.UserId,
                            "Nạp tiền thành công",
                            $"Nạp thành công {transaction.Amount:N0} VNĐ qua PayOS. Số dư mới của bạn là: {wallet.Balance:N0} VNĐ.",
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
                _logger.LogError(ex, "ConfirmPayment error for orderCode {OrderCode}", orderCode);
                return false;
            }
        }

        public async Task<string?> GetPaymentLinkByOrderCodeAsync(long orderCode)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PayOS");
                var response = await client.GetAsync($"{PayOSApiBase}/v2/payment-requests/{orderCode}");
                var responseStr = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("PayOS GetPaymentLink failed for {OrderCode}: {Status}. Attempting to re-create...", orderCode, response.StatusCode);
                    // Fallback: Re-create link if PENDING
                    var transaction = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);
                    if (transaction != null && transaction.Status == TransactionStatus.PENDING && transaction.Type == TransactionType.TOPUP)
                    {
                        // Generate a NEW orderCode because PayOS won't allow re-creation with the same one
                        long newOrderCode = GenerateOrderCode();
                        _logger.LogInformation("Regenerating OrderCode for transaction {OldCode} -> {NewCode}", orderCode, newOrderCode);

                        transaction.OrderCode = newOrderCode;
                        _walletRepository.UpdateTransaction(transaction);
                        await _unitOfWork.CompleteAsync();

                        return await CreatePayOSRequestAsync(newOrderCode, (int)transaction.Amount, transaction.Description);
                    }
                    return null;
                }

                using var doc = JsonDocument.Parse(responseStr);
                var root = doc.RootElement;

                if (root.GetProperty("code").GetString() == "00")
                {
                    var data = root.GetProperty("data");
                    if (data.TryGetProperty("checkoutUrl", out var urlEl))
                    {
                        return urlEl.GetString();
                    }
                }

                // If code is not 00 but we have transaction, try re-creating anyway (maybe it was deleted on PayOS)
                var fallbackTx = await _walletRepository.GetTransactionByOrderCodeAsync(orderCode);
                if (fallbackTx != null && fallbackTx.Status == TransactionStatus.PENDING && fallbackTx.Type == TransactionType.TOPUP)
                {
                    long newOrderCode = GenerateOrderCode();
                    _logger.LogInformation("Regenerating OrderCode (Fallback) for transaction {OldCode} -> {NewCode}", orderCode, newOrderCode);

                    fallbackTx.OrderCode = newOrderCode;
                    _walletRepository.UpdateTransaction(fallbackTx);
                    await _unitOfWork.CompleteAsync();

                    return await CreatePayOSRequestAsync(newOrderCode, (int)fallbackTx.Amount, fallbackTx.Description);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment link for orderCode {OrderCode}", orderCode);
                return null;
            }
        }


        private async Task<bool> VerifyWithSdkAsync(PayOSWebhookBody body)
        {
            try
            {
                if (body.Data == null) return false;

                var webhookData = new WebhookData
                {
                    OrderCode = body.Data.OrderCode,
                    Amount = body.Data.Amount,
                    Description = body.Data.Description,
                    AccountNumber = body.Data.AccountNumber ?? string.Empty,
                    Reference = body.Data.Reference ?? string.Empty,
                    TransactionDateTime = body.Data.TransactionDateTime ?? string.Empty,
                    Currency = body.Data.Currency ?? string.Empty,
                    PaymentLinkId = body.Data.PaymentLinkId ?? string.Empty,
                    Code = body.Data.Code ?? string.Empty,
                    CounterAccountBankId = body.Data.CounterAccountBankId ?? string.Empty,
                    CounterAccountBankName = body.Data.CounterAccountBankName ?? string.Empty,
                    CounterAccountName = body.Data.CounterAccountName,
                    CounterAccountNumber = body.Data.CounterAccountNumber ?? string.Empty,
                    VirtualAccountName = body.Data.VirtualAccountName ?? string.Empty,
                    VirtualAccountNumber = body.Data.VirtualAccountNumber ?? string.Empty,
                };

                typeof(WebhookData).GetProperty("Description2")?.SetValue(webhookData, body.Data.Desc ?? string.Empty);

                var webhook = new Webhook
                {
                    Code = body.Code,
                    Success = body.Success,
                    Signature = body.Signature,
                    Data = webhookData,
                };

                typeof(Webhook).GetProperty("Description")?.SetValue(webhook, body.Desc ?? string.Empty);

                var result = await _sdkClient.Webhooks.VerifyAsync(webhook);
                return result != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PayOS Verify Error: {Message}", ex.Message);
                return false;
            }
        }

        private long GenerateOrderCode()
        {
            var rnd = new Random();
            return (DateTimeOffset.UtcNow.ToUnixTimeSeconds() % 900_000_000L) + rnd.Next(1_000, 9_999);
        }
    }
}
