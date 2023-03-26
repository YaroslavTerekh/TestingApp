using FluentValidation;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.CreateTest;

public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
{
    public CreateTestCommandValidator(DataContext _context)
    {
        RuleFor(t => t.Title)
            .MinimumLength(4)
            .WithMessage(ErrorMessages.TestTitleTooShort)
            .MaximumLength(30)
            .WithMessage(ErrorMessages.TestTitleTooLong);

        RuleFor(t => t.Description)
            .MinimumLength(50)
            .WithMessage(ErrorMessages.DescriptionTitleTooShort)
            .MaximumLength(1000)
            .WithMessage(ErrorMessages.DescriptionTitleTooLong);
    }
}
