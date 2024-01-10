using MovieWatchlist.Models;
using FluentValidation;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(1, 50);

        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(1, 50);

        RuleFor(x => x.Overview)
            .Length(6, 16);
    }
}
