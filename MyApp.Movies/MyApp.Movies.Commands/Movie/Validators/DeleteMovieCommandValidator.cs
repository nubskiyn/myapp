using FluentValidation;

namespace MyApp.Movies.Commands.Movie.Validators
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}