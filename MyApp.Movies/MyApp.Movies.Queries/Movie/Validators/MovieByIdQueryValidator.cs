using FluentValidation;

namespace MyApp.Movies.Queries.Movie.Validators
{
    public class MovieByIdQueryValidator : AbstractValidator<MovieById>
    {
        public MovieByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.FallbackLanguageId).NotEqual(x => x.LanguageId);
        }
    }
}