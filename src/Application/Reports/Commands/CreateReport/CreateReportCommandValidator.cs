using FluentValidation;


namespace ReportingSystem.Application.Reports.Commands.CreateReport;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("The title must be at least 3 characters long.")
            .MaximumLength(200).WithMessage("The title must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("The description must not exceed 2000 characters.");
    }
}