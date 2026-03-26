using FluentValidation;
using SmartRecruit.Application.DTO.Job;

namespace SmartRecruit.Application.Validations.Job
{
    public class JobDraftRequestValidator : AbstractValidator<JobDraftRequest>
    {
        public JobDraftRequestValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("Tiêu đề không được vượt quá 100 ký tự");
            
            RuleFor(x => x.Company)
                .MaximumLength(100).WithMessage("Tên công ty không được quá 100 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(5000).WithMessage("Mô tả không được quá 5000 ký tự");

            RuleFor(x => x.SalaryMin)
                .GreaterThanOrEqualTo(0).WithMessage("Lương tối thiểu không được âm");

            RuleFor(x => x.SalaryMax)
                .GreaterThanOrEqualTo(x => x.SalaryMin).WithMessage("Lương tối đa phải lớn hơn hoặc bằng lương tối thiểu");

            RuleFor(x => x.Location)
                .MaximumLength(500).WithMessage("Địa điểm không được quá 500 ký tự");

            RuleFor(x => x.SkillsRequired)
                .MaximumLength(2000).WithMessage("Kỹ năng yêu cầu không được vượt quá 2000 ký tự")
                .When(x => !string.IsNullOrEmpty(x.SkillsRequired));

            RuleFor(x => x.ExpireDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Ngày hết hạn phải ở trong tương lai")
                .When(x => x.ExpireDate.HasValue);
        }
    }
}
