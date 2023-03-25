using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.GetMyTests;

public class GetMyTestsQueryValidator : AbstractValidator<GetMyTestsQuery>
{
    public GetMyTestsQueryValidator(DataContext _context)
    {
        RuleFor(t => t.CurrentUserId)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired)
            .MustAsync(async (id, cancellationToken) => await _context.Users.Where(t => t.Id == id).AnyAsync(cancellationToken))
            .WithMessage(ErrorMessages.TestNotFound);
    }
}
