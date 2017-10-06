using FluentValidation;

namespace MyApp.Movies.Commands.Movie.Validators
{
    public class AddMovieTranslationCommandValidator : AbstractValidator<AddMovieTranslationCommand>
    {
        public AddMovieTranslationCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}