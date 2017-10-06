using FluentValidation;

namespace MyApp.Movies.Queries.Movie.Validators
{
    public class MoviesQueryValidator : AbstractValidator<MoviesQuery>
    {
        public MoviesQueryValidator()
        {
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.FallbackLanguageId).NotEqual(x => x.LanguageId);
            // ...
            // Validation Rules
        }
    }
}