using FluentValidation;
using Dto.Movie;

public class CreateMovieValidator : AbstractValidator<CreateMovieRequest>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(5, 15);

        RuleFor(x => x.Overview)
            .NotEmpty()
            .Length(10, 50);
    }
}
