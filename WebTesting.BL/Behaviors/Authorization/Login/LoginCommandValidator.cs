using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.Constants;

namespace WebTesting.BL.Behaviors.Authorization.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
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
