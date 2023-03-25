using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.DeleteQuestion;

public class DeleteQuestionCommandValidator : AbstractValidator<DeleteQuestionCommand>
{
    public DeleteQuestionCommandValidator(DataContext _context)
    {
        RuleFor(t => t.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired)
            .MustAsync(async (id, cancellationToken) => await _context.Questions.Where(t => t.Id == id).AnyAsync(cancellationToken))
            .WithMessage(ErrorMessages.TestNotFound);
    }
}
