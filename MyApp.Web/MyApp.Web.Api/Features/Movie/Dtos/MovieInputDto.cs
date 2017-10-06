using System;

namespace MyApp.Web.Api.Features.Movie.Dtos
{
    public class MovieInputDto
    {
        public byte AgeFrom { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}