using FluentValidation;
using SmartRecruit.Application.DTO.Job;

namespace SmartRecruit.Application.Validations.Job
{
    public class JobUpdateRequestValidator : AbstractValidator<JobUpdateRequest>
    {
        public JobUpdateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Job title is required")
                .MinimumLength(5).WithMessage("Job title must be at least 5 characters")
                .MaximumLength(200).WithMessage("Job title cannot exceed 200 characters");

            RuleFor(x => x.Company).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Benefits).NotEmpty().MaximumLength(2000);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Job description is required")
                .MinimumLength(50).WithMessage("Job description must be at least 50 characters")
                .MaximumLength(5000).WithMessage("Job description cannot exceed 5000 characters");

            RuleFor(x => x.SalaryMin)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum salary cannot be negative");

            RuleFor(x => x.SalaryMax)
                .GreaterThanOrEqualTo(x => x.SalaryMin).WithMessage("Maximum salary must be greater than or equal to minimum salary");

             RuleFor(x => x.Requirement)
                .MaximumLength(4000).WithMessage("Requirement cannot exceed 4000 characters");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required")
                .MaximumLength(500).WithMessage("Location cannot exceed 500 characters");

            RuleFor(x => x.JobType)
                .IsInEnum().WithMessage("Invalid Job Type");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category is required");
        }
    }
}
