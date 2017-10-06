using FluentValidation;

namespace MyApp.Movies.Commands.Movie.Validators
{
    public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
    {
        public AddMovieCommandValidator()
        {
            // Validaton Rules
        }
    }
}