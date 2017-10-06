using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MyApp.Movies.Commands.Movie;

namespace MyApp.Movies.Commands.Ado.Movie
{
    public class DeleteMovieCommandHandler : BaseCommandHandler<DeleteMovieCommand>
    {
        public override async Task Handle(DeleteMovieCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            const string sql = "DELETE FROM movies WHERE id = @Id";
            await Connection.ExecuteAsync(sql, command);
        }
    }
}