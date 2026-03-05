namespace SmartRecruit.Infrastructure.Configurations
{
    public class PayOSSettings
    {
        public string ClientId { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string ChecksumKey { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;
        public string CancelUrl { get; set; } = string.Empty;
        /// <summary>Chỉ dùng trong Development để skip verify webhook signature</summary>
        public bool SkipSignatureVerification { get; set; } = false;
    }
}
