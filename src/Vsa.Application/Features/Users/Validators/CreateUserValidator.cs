using FastEndpoints;
using FluentValidation;

namespace Vsa.Application.Features.Users.Validators;

public class CreateUserValidator : Validator<UserInsertRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Age)
            .NotNull()
            .GreaterThanOrEqualTo(18);
    }
}
