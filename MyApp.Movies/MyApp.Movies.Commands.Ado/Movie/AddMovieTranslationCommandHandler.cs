using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MyApp.Movies.Commands.Movie;

namespace MyApp.Movies.Commands.Ado.Movie
{
    public class AddMovieTranslationCommandHandler : BaseCommandHandler<AddMovieTranslationCommand>
    {
        public override async Task Handle(AddMovieTranslationCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            const string sql = "INSERT INTO movie_translations VALUES (@MovieId, @LanguageId, @Name, @Description)";
            await Connection.ExecuteAsync(sql, command);
        }
    }
}