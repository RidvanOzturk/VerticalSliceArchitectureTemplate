using FastEndpoints;
using FluentValidation;
using Vsa.Application.Features.Settings.Models;

namespace Vsa.Application.Features.Settings.Validators;

public sealed class UpdateSettingValidator : Validator<SettingUpdateRequest>
{
    public UpdateSettingValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Key)
            .NotEmpty()
            .MaximumLength(200)
            .Must(k => k.Trim().Length == k.Length)
            .WithMessage("Key must not start or end with whitespace.");

        RuleFor(x => x.Value)
            .NotEmpty()
            .MaximumLength(100)
            .Must(v => !string.IsNullOrWhiteSpace(v))
            .WithMessage("Value cannot be whitespace.");
    }
}
