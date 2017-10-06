using System;
using System.Collections.Generic;

namespace MyApp.Web.Api.Features.Movie.Dtos
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte AgeFrom { get; set; }
        public int Duration { get; set; }
        public Dictionary<Guid, string> Genres { get; set; }
        public Dictionary<Guid, string> Countries { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}