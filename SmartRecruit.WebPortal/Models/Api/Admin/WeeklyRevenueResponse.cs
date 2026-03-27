using System.Collections.Generic;

namespace WebPortal.Models.Api.Admin
{
    public class WeeklyRevenueResponse
    {
        public List<decimal> Revenue { get; set; } = new();
    }
}
