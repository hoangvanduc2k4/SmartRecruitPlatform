using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models
{
    public class Job
    {
        public long Id { get; set; }
        public long RecruiterId { get; set; }

        [Required(ErrorMessage = "Tiêu đề công việc là bắt buộc")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Tiêu đề phải từ 5 đến 100 ký tự")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên công ty là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên công ty không được quá 100 ký tự")]
        public string Company { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phúc lợi là bắt buộc")]
        public string Benefits { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mô tả công việc là bắt buộc")]
        [MinLength(50, ErrorMessage = "Mô tả công việc phải có ít nhất 50 ký tự để thu hút ứng viên")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yêu cầu công việc là bắt buộc")]
        public string Requirement { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kỹ năng yêu cầu là bắt buộc")]
        public string SkillsRequired { get; set; } = string.Empty;

        public IEnumerable<string> SkillsRequiredList =>
            string.IsNullOrWhiteSpace(SkillsRequired)
                ? Enumerable.Empty<string>()
                : SkillsRequired.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());

        [Required(ErrorMessage = "Lương tối thiểu là bắt buộc")]
        [Range(0, 1000000000, ErrorMessage = "Lương không hợp lệ")]
        public decimal SalaryMin { get; set; }

        [Required(ErrorMessage = "Lương tối đa là bắt buộc")]
        [Range(0, 2000000000, ErrorMessage = "Lương không hợp lệ")]
        public decimal SalaryMax { get; set; }

        [Required(ErrorMessage = "Loại hình công việc là bắt buộc")]
        public JobType JobType { get; set; }

        public JobStatus Status { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedTime { get; set; }

        [Required(ErrorMessage = "Ngày hết hạn là bắt buộc")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpireDate { get; set; }

        [Required(ErrorMessage = "Địa điểm làm việc là bắt buộc")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Danh mục công việc là bắt buộc")]
        [Range(1, long.MaxValue, ErrorMessage = "Vui lòng chọn danh mục hợp lệ")]
        public long? CategoryId { get; set; }

        public string Category { get; set; } = string.Empty;
        public bool IsBoosted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAppealed { get; set; }
        public string? ModerationNote { get; set; }
        public string? DraftChanges { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Address { get; set; }
        public string? LogoUrl { get; set; }
    }
}
