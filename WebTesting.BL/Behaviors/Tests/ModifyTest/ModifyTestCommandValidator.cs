using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.ModifyTest;

public class ModifyTestCommandValidator : AbstractValidator<ModifyTestCommand>
{
    public ModifyTestCommandValidator(DataContext _context)
    {
        RuleFor(t => t.Id)
            .MustAsync(async (test, cancellationToken) => await _context.Tests.Where(t => t.Id == test).AnyAsync(cancellationToken))
            .WithMessage(ErrorMessages.TestNotFound);

        RuleFor(t => t.Title)
            .MinimumLength(4)
            .WithMessage(ErrorMessages.TestTitleTooShort)
            .MaximumLength(4)
            .WithMessage(ErrorMessages.TestTitleTooLong);

        RuleFor(t => t.Description)
            .MinimumLength(50)
            .WithMessage(ErrorMessages.DescriptionTitleTooShort)
            .MaximumLength(1000)
            .WithMessage(ErrorMessages.DescriptionTitleTooLong);
    }
}
