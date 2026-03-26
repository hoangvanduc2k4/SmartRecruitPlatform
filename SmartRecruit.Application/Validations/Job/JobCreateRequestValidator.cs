using FluentValidation;
using SmartRecruit.Application.DTO.Job;

namespace SmartRecruit.Application.Validations.Job
{
    public class JobCreateRequestValidator : AbstractValidator<JobCreateRequest>
    {
        public JobCreateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Tiêu đề công việc là bắt buộc")
                .MinimumLength(5).WithMessage("Tiêu đề phải từ 5 đến 100 ký tự")
                .MaximumLength(100).WithMessage("Tiêu đề không được vượt quá 100 ký tự");
            
            RuleFor(x => x.Company)
                .NotEmpty().WithMessage("Tên công ty là bắt buộc")
                .MaximumLength(100).WithMessage("Tên công ty không được quá 100 ký tự");

            RuleFor(x => x.Benefits)
                .NotEmpty().WithMessage("Phúc lợi là bắt buộc")
                .MaximumLength(2000);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Mô tả công việc là bắt buộc")
                .MinimumLength(50).WithMessage("Mô tả công việc phải có ít nhất 50 ký tự")
                .MaximumLength(5000);

            RuleFor(x => x.Requirement)
                .NotEmpty().WithMessage("Yêu cầu công việc là bắt buộc")
                .MaximumLength(4000);

            RuleFor(x => x.SkillsRequired)
                .NotEmpty().WithMessage("Kỹ năng yêu cầu là bắt buộc")
                .MaximumLength(2000).WithMessage("Kỹ năng yêu cầu không được vượt quá 2000 ký tự");

            RuleFor(x => x.SalaryMin)
                .GreaterThanOrEqualTo(0).WithMessage("Lương tối thiểu không được âm");

            RuleFor(x => x.SalaryMax)
                .GreaterThanOrEqualTo(x => x.SalaryMin).WithMessage("Lương tối đa phải lớn hơn hoặc bằng lương tối thiểu");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Địa điểm là bắt buộc")
                .MaximumLength(500);

            RuleFor(x => x.JobType)
                .IsInEnum().WithMessage("Loại hình công việc không hợp lệ");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Vui lòng chọn danh mục công việc")
                .GreaterThan(0).WithMessage("Vui lòng chọn danh mục hợp lệ");

            RuleFor(x => x.ExpireDate)
                .NotEmpty().WithMessage("Ngày hết hạn là bắt buộc")
                .Must(date => date > DateTime.UtcNow).WithMessage("Ngày hết hạn phải ở trong tương lai");
        }
    }
}
