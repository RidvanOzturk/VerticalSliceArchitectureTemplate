using FastEndpoints;
using FluentValidation;

namespace Vsa.Application.Features.Users.Validators;

public class CreateUserValidator : Validator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Your name is required.")
            .MinimumLength(3).WithMessage("Your name must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("Your name cannot exceed 20 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");
        RuleFor(x => x.Age)
            .NotNull().WithMessage("Password is required.")
            .GreaterThanOrEqualTo(18).WithMessage("User must be at least 18 years old.");

    }
}
