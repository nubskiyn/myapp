using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Commands;
using MyApp.Core.Queries;
using MyApp.Movies.Commands.Movie;
using MyApp.Web.Api.Features.MovieTranslation.Dtos;
using MyApp.Web.Common;

namespace MyApp.Web.Api.Features.MovieTranslation
{
    [Produces("application/json")]
    [Route("api/movies/{id}/translations")]
    public class MovieTranslationController : ApiController
    {
        public MovieTranslationController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        [HttpPost("{id}")]
        public async Task Post(Guid id, [FromBody]MovieTranslationInputDto value)
        {
            await CommandDispatcher.Dispatch(new AddMovieTranslationCommand
            {
                Name = value.Title,
                Description = value.Description,
                LanguageId = RequestLanguageId,
                MovieId = id
            });
        }
    }
}
