using FluentValidation;

namespace MyApp.Movies.Queries.Genre.Validators
{
    public class GenreByIdQueryValidator : AbstractValidator<GenreByIdQuery>
    {
        public GenreByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.FallbackLanguageId).NotEqual(x => x.LanguageId);
        }
    }
}