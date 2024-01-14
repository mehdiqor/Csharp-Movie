using FluentValidation;

namespace MovieWatchlist.Validators;

public class GuidIdValidator : AbstractValidator<Guid>
{
    public GuidIdValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID must not be empty")
            .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("ID must be a valid GUID");
    }
}