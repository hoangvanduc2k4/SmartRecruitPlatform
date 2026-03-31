using System.Collections.Generic;

namespace SmartRecruit.Application.DTO.Admin
{
    public class WeeklyRevenueResponse
    {
        public List<decimal> Revenue { get; set; } = new();
    }
}
