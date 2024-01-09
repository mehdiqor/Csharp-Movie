using ErrorOr;

namespace MovieWatchlist.ServiceErrors;

public static class Errors
{
    public static class Movie
    {
        public static Error InvalidTitle => Error.Validation(
            code: "Movie.InvalidTitle",
            description: $"Movie title must be at least {Models.Movie.MinTitleLength} " +
            $"characters long and at most {Models.Movie.MaxTitleLength} characters long"
        );

        public static Error InvalidOverview => Error.Validation(
            code: "Movie.InvalidOverview",
            description: $"Movie overview must be at least {Models.Movie.MinOverviewLength} " +
            $"characters long and at most {Models.Movie.MaxOverviewLength} characters long"
        );

        public static Error NotFound => Error.NotFound(
            code: "Movie.NotFound",
            description: "Movie NotFound!!!"
        );
    }
}
