using FastEndpoints;
using FluentValidation;
using Vsa.Application.Features.Users.Models;

namespace Vsa.Application.Features.Users.Validators;

public sealed class CreateUserValidator : Validator<UserInsertRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Surname)
            .MaximumLength(150);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Age)
            .NotNull()
            .GreaterThanOrEqualTo(18);

        RuleFor(x => x.Sex)
            .IsInEnum();
    }
}
