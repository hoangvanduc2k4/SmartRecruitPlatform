namespace SmartRecruit.Application.DTO.Admin
{
    public class FinanceStatsResponse
    {
        // 1. CASH FLOW PERSPECTIVE (Money in/out)
        public decimal TotalCashInflow { get; set; } // Total successful top-up amount
        public decimal SystemCirculatingBalance { get; set; } // Sum of all wallet balances (Liability)

        // 2. RECOGNIZED REVENUE PERSPECTIVE (Service consumption)
        public decimal TotalRecognizedRevenue { get; set; } // Total value of consumed services (JOB_POST + BOOST + VIP + OTHER)

        // Detailed breakdown
        public decimal JobPostRevenue { get; set; }
        public decimal BoostRevenue { get; set; }
        public decimal VipRevenue { get; set; }
        public decimal OtherRevenue { get; set; }

        public int TotalTransactions { get; set; }
        public int PendingTransactions { get; set; }
        public int SuccessTransactions { get; set; }
        public int FailedTransactions { get; set; }
    }
}
