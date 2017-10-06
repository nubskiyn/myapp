using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Commands;
using MyApp.Core.Queries;
using MyApp.Movies.Commands.Movie;
using MyApp.Movies.Queries.Movie;
using MyApp.Web.Api.Features.Movie.Dtos;
using MyApp.Web.Common;
using MovieRM = MyApp.Movies.Queries.Movie.Models.Movie;

namespace MyApp.Web.Api.Features.Movie
{
    [Produces("application/json")]
    [Route("api/movies")]
    public class MovieController : ApiController
    {
        public MovieController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDto>> Get(MovieSearchDto search)
        {
            var movies = await QueryDispatcher.Dispatch<MoviesQuery, IEnumerable<MovieRM>>(new MoviesQuery
            {
                Title = search.Title,
                AgeFrom = search.AgeFrom,
                // ...
            });

            // Automapper.Map to IEnumerable<MovieDto>

            return new MovieDto[] { };
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<MovieDto> Get(Guid id)
        {
            var movie = await QueryDispatcher.Dispatch<MovieById, MovieRM>(new MovieById
            {
                Id = id,
                LanguageId = RequestLanguageId,
                FallbackLanguageId = DefaultLanguageId
            });

            // Automapper.Map to MovieDto

            return new MovieDto();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]MovieInputDto value)
        {
            var id = Guid.NewGuid();
            await CommandDispatcher.Dispatch(new AddMovieCommand
            {
                Id = id,
                AgeFrom = value.AgeFrom,
                Duration = value.Duration,
                ReleaseDate = value.ReleaseDate
            });

            return CreatedAtAction("Get", new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await CommandDispatcher.Dispatch(new DeleteMovieCommand { Id = id });
            return NoContent();
        }
    }
}
