using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator(DataContext _context)
    {
        RuleFor(t => t.TestId)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired)
            .MustAsync(async (e, cancellationToken) => await _context.Tests.Where(t => t.Id == e).AnyAsync())
            .WithMessage(ErrorMessages.TestNotFound);

        RuleFor(t => t.Text)
            .NotEmpty()
            .WithMessage(ErrorMessages.QuestionDescriptionRequired)
            .NotNull()
            .WithMessage(ErrorMessages.QuestionDescriptionRequired)
            .MaximumLength(50)
            .WithMessage(ErrorMessages.QuestionDescriptionTooLong);

        RuleFor(t => t.Options)
            .NotNull()
            .WithMessage(ErrorMessages.OptionsAreRequired);
    }
}
