using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MyApp.Movies.Commands.Movie;

namespace MyApp.Movies.Commands.Ado.Movie
{
    public class AddMovieCommandHandler : BaseCommandHandler<AddMovieCommand>
    {
        public override async Task Handle(AddMovieCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            const string sql = "INSERT INTO movies VALUES(@Id, @AgeFrom, @Duration, @ReleaseDate);";
            await Connection.ExecuteAsync(sql, command);
        }
    }
}