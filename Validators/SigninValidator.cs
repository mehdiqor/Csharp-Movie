using FluentValidation;
using Dto.User;

public class SigninValidator : AbstractValidator<SigninRequest>
{
    public SigninValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(6, 16);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
