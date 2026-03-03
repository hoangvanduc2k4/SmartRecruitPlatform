namespace SmartRecruit.Application.DTO.Payment
{
    /// <summary>
    /// Raw webhook payload từ PayOS - ánh xạ đúng theo cấu trúc JSON PayOS gửi về.
    /// Không phụ thuộc vào SDK Net.payOS để Application layer sạch.
    /// </summary>
    public class PayOSWebhookBody
    {
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public bool Success { get; set; }
        public PayOSWebhookData? Data { get; set; }
        public string Signature { get; set; } = string.Empty;
    }

    public class PayOSWebhookData
    {
        public long OrderCode { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string TransactionDateTime { get; set; } = string.Empty;
        public string PaymentLinkId { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string? CounterAccountBankId { get; set; }
        public string? CounterAccountBankName { get; set; }
        public string? CounterAccountName { get; set; }
        public string? CounterAccountNumber { get; set; }
        public string? VirtualAccountName { get; set; }
        public string? VirtualAccountNumber { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
