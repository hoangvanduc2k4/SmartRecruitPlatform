using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.Extensions
{
    public static class ApplicationStatusExtensions
    {
        /// <summary>
        /// Translates ApplicationStatus enum to Vietnamese display text
        /// </summary>
        public static string ToVietnamese(this ApplicationStatus status)
        {
            return status switch
            {
                ApplicationStatus.REVIEWING => "Đang xem xét",
                ApplicationStatus.INTERVIEWING => "Phỏng vấn",
                ApplicationStatus.OFFERED => "Đã mời làm",
                ApplicationStatus.REJECTED => "Đã từ chối",
                _ => status.ToString()
            };
        }
    }
}
