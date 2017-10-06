using System;
using System.Collections.Generic;

namespace MyApp.Movies.Queries.Movie.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte AgeFrom { get; set; }
        public int Duration { get; set; }
        public Dictionary<Guid, string> Genres { get; set; }
        public IEnumerable<Guid> CountryIds { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}