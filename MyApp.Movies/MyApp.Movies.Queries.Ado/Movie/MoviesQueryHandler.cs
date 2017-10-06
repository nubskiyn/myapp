using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MoviesQuery = MyApp.Movies.Queries.Movie.MoviesQuery;
using MovieModel = MyApp.Movies.Queries.Movie.Models.Movie;

namespace MyApp.Movies.Queries.Ado.Movie
{
    public class MoviesQueryHandler : BaseQueryHandler<MoviesQuery, IEnumerable<MovieModel>>
    {
        public override async Task<IEnumerable<MovieModel>> Handle(MoviesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var sql = query.FallbackLanguageId == Guid.Empty
                ? @"SELECT m.* 
                    des.title as Title, 
                    des.description as Description,
                    FROM movies m
                    LEFT JOIN movie_translations des ON m.id = des.movie_id AND des.language_id = @LanguageId"

                : @"SELECT m.*, 
                    COALESCE(des.title, def.title) as Title,
                    COALESCE(des.description, def.description) as Description
                    FROM movies m
                    LEFT JOIN movie_translations des ON m.id = des.movie_id AND des.language_id = @LanguageId
                    LEFT JOIN movie_translations def ON m.id = def.movie_id AND def.language_id = @FallbackLanguageId";

            sql += "\nWHERE Title LIKE @Title"; // etc.
            return await Connection.QueryAsync<MovieModel>(sql, query);
        }
    }
}