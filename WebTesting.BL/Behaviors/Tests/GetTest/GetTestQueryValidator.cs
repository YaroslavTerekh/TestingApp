﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Tests.GetTest;

public class GetTestQueryValidator : AbstractValidator<GetTestQuery>
{
    public GetTestQueryValidator(DataContext _context)
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

        RuleFor(t => t.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.IdIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdIsRequired)
            .MustAsync(async (id, cancellationToken) => await _context.Tests.Where(t => t.Id == id).AnyAsync(cancellationToken))
            .WithMessage(ErrorMessages.TestNotFound);
    }
}
