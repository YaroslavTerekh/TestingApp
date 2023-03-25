using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.CompleteTest;

public class CompleteTestCommandValidator : AbstractValidator<CompleteTestCommand>
{
    public CompleteTestCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired);

        RuleFor(t => t.CurrentUserId)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired);

        RuleFor(t => t.CheckAnswers)
            .NotNull()
            .WithMessage(ErrorMessages.AnswersAreRequired);
    }
}
