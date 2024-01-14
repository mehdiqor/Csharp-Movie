using FluentValidation;
using MovieWatchlist.Dtos;

public class SignupValidator : AbstractValidator<CreateUser>
{
    public SignupValidator()
    {
        RuleFor(x => x.Fullname)
            .NotEmpty()
            .Length(5, 20);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(6, 16);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
            // .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
   }
}
