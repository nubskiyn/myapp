using FluentValidation;

namespace MyApp.Movies.Queries.Genre.Validators
{
    public class GenresQueryValidator : AbstractValidator<GenresQuery>
    {
        public GenresQueryValidator()
        {
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.FallbackLanguageId).NotEqual(x => x.LanguageId);
        }
    }
}