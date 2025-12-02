using FastEndpoints;
using FluentValidation;
using Vsa.Application.Features.Users.Models;

namespace Vsa.Application.Features.Users.Validators;

public sealed class UpdateUserValidator : Validator<UserUpdateRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.Age)
            .NotNull()
            .GreaterThanOrEqualTo(18);
    }
}
