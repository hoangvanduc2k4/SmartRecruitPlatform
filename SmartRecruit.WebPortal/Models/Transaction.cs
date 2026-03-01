using System;

namespace SmartRecruitWeb.Models
{
    public class Transaction
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "TOPUP"; // TOPUP, SPEND
        public DateTime CreatedAt { get; set; }
    }
}
