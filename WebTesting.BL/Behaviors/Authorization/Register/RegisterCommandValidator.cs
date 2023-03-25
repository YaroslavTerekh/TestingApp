using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Authorization.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(t => t.UserName)
            .NotEmpty()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("User"))
            .NotNull()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("User"))
            .MinimumLength(2)
            .WithMessage(ErrorMessages.PrefixNameIsTooShort("User"))
            .MaximumLength(30)
            .WithMessage(ErrorMessages.PrefixNameIsTooLong("User"));

        RuleFor(t => t.FirstName)
            .NotEmpty()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("First"))
            .NotNull()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("First"))
            .MinimumLength(2)
            .WithMessage(ErrorMessages.PrefixNameIsTooShort("First"))
            .MaximumLength(15)
            .WithMessage(ErrorMessages.PrefixNameIsTooLong("First"));

        RuleFor(t => t.LastName)
            .NotEmpty()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("Last"))
            .NotNull()
            .WithMessage(ErrorMessages.PrefixNameIsRequired("Last"))
            .MinimumLength(2)
            .WithMessage(ErrorMessages.PrefixNameIsTooShort("Last"))
            .MaximumLength(15)
            .WithMessage(ErrorMessages.PrefixNameIsTooLong("Last"));

        RuleFor(t => t.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.EmailIsRequired)
            .NotNull()
            .WithMessage(ErrorMessages.EmailIsRequired)
            .EmailAddress()
            .WithMessage(ErrorMessages.EmailIsWrong);

        RuleFor(t => t.Password)
            .NotNull()
            .WithMessage(ErrorMessages.PasswordIsRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.PasswordIsRequired)
            .MinimumLength(6)
            .WithMessage(ErrorMessages.PasswordIsTooShort);
    }
}

